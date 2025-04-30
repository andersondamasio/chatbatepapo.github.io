const fs = require("fs");
const axios = require("axios");

const OPENAI_API_KEY = process.env.OPENAI_API_KEY;

async function gerarFrase() {
  const prompt = "Crie uma frase engraçada para chat com emojis. Resposta apenas com a frase.";
  try {
    const res = await axios.post("https://api.openai.com/v1/chat/completions", {
      model: "gpt-3.5-turbo",
      messages: [{ role: "user", content: prompt }],
      temperature: 0.8
    }, {
      headers: {
        Authorization: `Bearer ${OPENAI_API_KEY}`,
        "Content-Type": "application/json"
      }
    });
    const frase = res.data.choices[0].message.content.trim();
    fs.mkdirSync("public/frases", { recursive: true });
    fs.writeFileSync("public/frases/frase-do-dia.txt", frase);
    console.log("✅ Frase:", frase);
  } catch (err) {
    console.error("❌ Erro:", err.message);
  }
}
gerarFrase();