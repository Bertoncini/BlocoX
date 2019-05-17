[![Build status](https://ci.appveyor.com/api/projects/status/32r7s2skrgm9ubva/branch/master?svg=true)](https://ci.appveyor.com/project/Bertoncini/blocox/branch/master) 
[![Issues](https://img.shields.io/github/issues/Bertoncini/BlocoX.svg?style=flat-square)](https://github.com/Bertoncini/BlocoX/issues)


BlocoX
=================
Grupo [Skype](https://join.skype.com/merZOqMzfxqP) para discussão

Grupo [Discord](https://discord.gg/kd4m5N8) para discussão

Biblioteca para geração e emissão do BlocoX (ReduçãoZ e Estoque) conforme despacho https://www.confaz.fazenda.gov.br/legislacao/despacho/2017/dp045_17

A biblioteca foi desenvolvida em C# utilizando como IDE o Visual Studio Community 2019. Atualmente utiliza o .NetFramework na versão 4.5.

Está licenciada sobre a *LGPL* (https://pt.wikipedia.org/wiki/GNU_Lesser_General_Public_License).


**O que a biblioteca faz:**
------------------
O projeto traz classes construídas de forma manual que extraem a complexidade dos XSDs. Com isso é possível preencher objetos nativos em .NET ou Json e gerar o XML na estrutura exigida para seu BlocoX, assim como o processo inverso de ler um XML de um BlocoX e obter objetos nativos em .NET ou Json.

Além da serialização e desserialização, o projeto também conta com os métodos de consumo dos webservices (Consultar, COnsultarSituacaoPafEcf, Enviar e Validar), ou seja, com a biblioteca você preenche um objeto nativo em .NET e transmite o seu BlocoX de forma totalmente transparente, sem se preocupar com a serialização e o consumo do webservice.


**Como usar a ferramenta:**
-----------
Antes de qualquer coisa leia os manuais e conheça à fundo o(s) projetos que pretende usar, entenda o que é e como funciona um webservice, o que é obrigatório ser informado no BlocoX que pretende emitir, entre outras informações. Isso vai ajudar na construção do seu software e na integração com a biblioteca.

Com o conhecimento prévio adquirido, agora você precisa estudar a biblioteca. A linguagem utilizada é C#, logo um conhecimento basico da linguagem pode te ajudar bastante, mesmo que você use apenas as dlls com VB.Net, C# ou outra linguagem compatível.

Para facilitar o seus estudos a biblioteca oferece projeto do tipo DEMO:
- *BlocoX.AppTeste:* Projeto em WPF para demonstração de uso do BlocoX (ReduçãoZ e Estoque);


**Suporte:**
---------
O uso dessa biblioteca não lhe dá quaisquer garantias de suporte. No entanto se tiver dúvidas a respeito do uso desta biblioteca, abra um novo Issue aqui mesmo no github ou pergunte no grupo skype.
