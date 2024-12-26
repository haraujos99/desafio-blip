# Teste Técnico - Chatbot Blip

Este repositório contém a implementação do teste técnico solicitado pela Blip para a vaga de Desenvolvedor Pleno. O projeto foi desenvolvido com foco em boas práticas, organização do código e uso das tecnologias requisitadas.

---

## 📋 Descrição

Este projeto consiste na criação de um ChatBot na plataforma Blip(https://account.blip.ai) que realiza uma integração com a API pública do GitHub através de uma API RESTful intermediária.

---

## 🛠️ Tecnologias Utilizadas

- **Linguagem/Framework:** C# ASP.NET 8.0
- **Outras Ferramentas:** Swagger, Serilog
- **Deploy:** Microsoft Azure

---

## 🚀 Funcionalidades Implementadas

A API intermediária está disponível em: https://apigithubmiddleware-c3fuazfgdndugvgc.brazilsouth-01.azurewebsites.net/GitHub/LastFiveCSharpRepo

Já direcionada para a única rota existente, que traz o retorno solicitado no desafio para a integração com o chatbot.

A rota é responsável por acessar os repositórios mais antigos da organização, filtrar por linguagem e ordenar do mais velho ao mais novo os 5 ultimos reposítórios da limguagem C#.

## 🔧 Como Executar o Projeto

### Pré-requisitos

- .NET SDK 8.0 ou superior instalado

### Passo a Passo

1. Clone o repositório:
   ```bash
   git clone https://github.com/haraujos99/desafio-blip.git

2. Navegue até o diretório API

3. Abra a solução "GithubMiddlewareAPI.sln"

4. Altere o arquivo "appsettings.json", adicionando o valor do token.
(Como gerar o token: https://docs.github.com/pt/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens#como-criar-um-personal-access-token-classic)

5. Garanta que a solução está em modo Debug

6. Execute
(A URI do método utilizado é: "/GitHub/LastFiveCSharpRepo")

## ✍🏼 Notas de desenvolvimento

1. O Figma diz que ao selecionar o botão "Voltar ao menu inicial" após algum erro de API o fluxo deve retornar para o ponto anterior, que não necessáriamente será o menu inicial. Segui essa instrução.

2. O documento do desafio diz que os cards dos repositórios devem mostrar o avatar da Blip no Github, mas no fluxo do figma a imagem é outra. Deixei como está no documento.

3. Senti falta de uma maneira de atribuir valor a mais de uma variável no script, pouparia trabalho.

## Considerações finais

Apesar do curto tempo disponível para o desenvolvimento por causa dos eventos de fim de ano, foi um prazer atuar nesse desafio. Pude explorar bem a plataforma blip, que é super completa e intuitiva em todo o processo de desenvolvimento, além de ter aplicado boas práticas no desenvolvimento da API intermediária, dividindo bem as responsabilidades dos métodos e classes e fazendo um mapeamento de logs que facilitam o entendimento e análise de erros da aplicação.