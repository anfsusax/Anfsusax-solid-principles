# Arquitetura Bíblica UI

Interface construída em **Angular 17** que apresenta os princípios SOLID com narrativas bíblicas e módulos de estudo. O aplicativo consome a API hospedada na Railway e é publicado na Vercel.

## 👀 Live
- Frontend: https://anfsusax-solid-principles.vercel.app
- API: https://anfsusax-solid-principles-production.up.railway.app/swagger/index.html

## ✨ Principais Recursos
- Catálogo interativo dos princípios SOLID
- Cards com resumos, explicações passo a passo e trechos bíblicos
- Exemplo de código formatado em blocos por responsabilidade
- Página de detalhes com visual responsivo e botão persistente de navegação
- Detecção automática do endpoint da API (local vs produção)

## 🛠️ Stack
- Angular 17 (Standalone Components)
- Angular Material (botões, ícones, spinners)
- SCSS modular com temas teal/dourado
- RxJS para integração com a API
- Deploy na Vercel

## ⚙️ Configuração
```bash
# instalar dependências
npm install

# ambiente local (frontend em :4200 e API em :5278)
npm run start
```
A aplicação detecta automaticamente o host:
- Local (`localhost`/`127.0.0.1`) → `http://localhost:5278/api/solid`
- Produção → `https://anfsusax-solid-principles-production.up.railway.app/api/solid`

## 🧪 Scripts úteis
```bash
npm run start       # ng serve com HMR
npm run build       # build production (saída em dist/arquitetura-biblica-ui/browser)
npm run test        # testes unitários (Karma)
```

## 📁 Estrutura de pastas
```
src/
 ├─ app/
 │   ├─ components/
 │   │   ├─ home/             # grade de princípios
 │   │   └─ principle-detail/ # página detalhada
 │   ├─ services/
 │   │   └─ solid-principles.ts
 │   ├─ shared/
 │   │   └─ principle-guides.ts
 │   ├─ app.routes.ts
 │   └─ app.config.ts
 └─ styles.scss
```

## 🌐 Deploy na Vercel
- Root Directory: `frontend/arquitetura-biblica-ui`
- Output Directory: `dist/arquitetura-biblica-ui/browser`
- Build Command: `npm run build`
- Instalação: `npm install`

Ao alterar a API, garanta que o domínio correspondente esteja liberado no CORS.

## 🤝 Contribuindo
1. `git checkout -b feature/minha-feature`
2. Faça commits descritivos
3. Abra um PR explicando o racional e screenshots se possível

## 📄 Licença
Projeto mantido para fins educacionais. Consulte o autor antes de reutilizar.
