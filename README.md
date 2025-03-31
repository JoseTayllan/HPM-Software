HPM Software - Preenchimento de Planilha do Google Sheets a partir de PDFs de Guias Hospitalares
🏥 Descrição
O HPM Software é uma aplicação desenvolvida em C# com Windows Forms que automatiza o preenchimento de uma planilha do Google Sheets com dados extraídos de arquivos PDF de guias hospitalares. Esse processo otimiza a organização das informações hospitalares, reduzindo o trabalho manual e possíveis erros.

✨ Funcionalidades
✅ Interface gráfica intuitiva desenvolvida com Windows Forms.
✅ Seleção de arquivos PDF para extração de dados.
✅ Processamento automático das informações dos PDFs.
✅ Integração com o Google Sheets API para preenchimento da planilha.
✅ Opção para visualizar e revisar os dados antes do envio.

🛠 Tecnologias Utilizadas
C# (.NET Windows Forms) - Desenvolvimento da aplicação desktop.

iTextSharp - Biblioteca para leitura e extração de texto dos arquivos PDF.

Google Sheets API - Para interação com planilhas no Google Sheets.

Google APIs Client Library - Para autenticação e comunicação com os serviços do Google.

🚀 Como Rodar o Projeto
1️⃣ Clonar o Repositório
bash
Copiar código
git clone https://github.com/JoseTayllan/HPM-Software.git
cd HPM-Software
2️⃣ Instalar Dependências
Abra o projeto no Visual Studio e instale os pacotes necessários via NuGet:

bash
Copiar código
dotnet restore
Ou instale manualmente os pacotes via Gerenciador de Pacotes NuGet no Visual Studio:

iTextSharp (para leitura de PDFs).

Google.Apis.Sheets.v4 (para comunicação com o Google Sheets).

3️⃣ Configurar a API do Google Sheets
Acesse o Google Developer Console.

Crie um novo projeto e ative a Google Sheets API.

Gere credenciais de acesso e baixe o arquivo credentials.json.

Coloque o arquivo credentials.json na pasta raiz do projeto.

4️⃣ Executar o Projeto
Após a configuração das credenciais, execute a aplicação pelo Visual Studio ou pelo terminal:

bash
Copiar código
dotnet run
Agora, basta selecionar os arquivos PDF desejados e deixar que o software extraia e envie os dados para o Google Sheets automaticamente.

🤝 Contribuições
Contribuições são bem-vindas! Para colaborar:

Faça um fork do repositório.

Crie uma branch com suas modificações.

Envie um pull request com sua contribuição.

📜 Licença
Este projeto está licenciado sob a Licença MIT.
