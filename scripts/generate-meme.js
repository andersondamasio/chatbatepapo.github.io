const axios = require('axios');
const FormData = require('form-data');
const googleTrends = require('google-trends-api');
const OpenAI = require('openai');

const openai = new OpenAI({
    apiKey: process.env.OPENAI_API_KEY
});

async function buscarTopTemasBrasil() {
    try {
        const resultados = await googleTrends.dailyTrends({ geo: 'BR', hl: 'pt-BR' });
        const trends = JSON.parse(resultados);
        const temas = trends.default.trendingSearchesDays[0].trendingSearches.map(item => item.title.query);
        if (!temas.length) throw new Error('Nenhum tema encontrado.');
        return temas[Math.floor(Math.random() * temas.length)];
    } catch (error) {
        console.error('⚠️ Erro ao buscar Google Trends:', error.message);
        return "Memes Aleatórios";
    }
}

async function gerarTextoMemeComChatGPT(tema) {
    const prompt = `Crie uma frase curta e engraçada de meme em português do Brasil sobre o tema "${tema}". Use humor brasileiro, memes atuais e mantenha a frase com no máximo 80 caracteres.`;

    const response = await openai.chat.completions.create({
        model: "gpt-3.5-turbo",
        messages: [{ role: "user", content: prompt }],
        max_tokens: 80,
        temperature: 0.9
    });

    return response.choices[0].message.content.trim();
}

async function buscarImagemPixabay(tema) {
    const apiKey = process.env.PIXABAY_API_KEY;
    const response = await axios.get(`https://pixabay.com/api/?key=${apiKey}&q=${encodeURIComponent(tema)}&image_type=photo&lang=pt`);
    const hits = response.data.hits;
    if (!hits.length) {
        const fallback = await axios.get(`https://pixabay.com/api/?key=${apiKey}&q=meme&image_type=photo&lang=pt`);
        if (!fallback.data.hits.length) throw new Error('Nenhuma imagem encontrada no Pixabay.');
        return fallback.data.hits[0].largeImageURL;
    }
    return hits[0].largeImageURL;
}

async function postarNoFacebook(imagemURL, texto) {
    const pageAccessToken = process.env.FACEBOOK_PAGE_ACCESS_TOKEN;

    console.log('📷 Baixando imagem para upload...');
    const imageResponse = await axios.get(imagemURL, { responseType: 'arraybuffer' });
    const imageBuffer = Buffer.from(imageResponse.data, 'binary');

    console.log('📤 Enviando imagem para o Facebook...');
    const formData = new FormData();
    formData.append('caption', texto);
    formData.append('access_token', pageAccessToken);
    formData.append('source', imageBuffer, {
        filename: 'meme.jpg',
        contentType: 'image/jpeg'
    });

    try {
        const res = await axios.post('https://graph.facebook.com/v19.0/me/photos', formData, {
            headers: {
                ...formData.getHeaders()
            },
            maxContentLength: Infinity,
            maxBodyLength: Infinity
        });
        console.log('✅ Meme postado no Facebook:', res.data);
    } catch (error) {
        console.error('❌ Erro ao postar no Facebook:', error.response ? error.response.data : error.message);
        throw error;
    }
}

async function main() {
    try {
        const tema = await buscarTopTemasBrasil();
        console.log('🎯 Tema escolhido:', tema);
        const fraseMeme = await gerarTextoMemeComChatGPT(tema);
        console.log('📝 Frase do meme:', fraseMeme);
        const imagemURL = await buscarImagemPixabay(tema);
        console.log('🌐 Imagem URL:', imagemURL);
        await postarNoFacebook(imagemURL, fraseMeme);
    } catch (error) {
        console.error('❌ Erro geral:', error.message);
    }
}

main();
