const fs = require('fs');

const nomes = ["Ana", "Pedro", "Lu", "Hacker", "Nando"];
const sufixos = ["_BR", "2025", "Gamer", "_doZap"];
const frases = [
  "Manda zap aí! 👀", "KKKKKK essa foi boa 😂", "Só entro aqui pra rir mesmo 🤣"
];

const getRandom = arr => arr[Math.floor(Math.random() * arr.length)];

const nickname = getRandom(nomes) + getRandom(sufixos);
const frase = getRandom(frases);
const html = `<html><body><h2>Nick: ${nickname}</h2><p>${frase}</p></body></html>`;

fs.mkdirSync("public/tendencias", { recursive: true });
fs.writeFileSync("public/tendencias/index.html", html);