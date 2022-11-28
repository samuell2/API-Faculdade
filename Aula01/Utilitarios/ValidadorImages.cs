namespace Aula01.Utilitarios
{
    public static class ValidadorImages
    {
        private static bool Extensao(string teste)
        {
            List<string> listaExtensoes = new List<string>();
            listaExtensoes.Add("jpg");
            listaExtensoes.Add("png");
            listaExtensoes.Add("jpg");

            if (listaExtensoes.Contains(teste)) return true;
            else return false;
        }

        public static async Task<ValidadorArquivo> UploadArquivo(IFormFile arquivo, string imgNome)
        {
            string[] arquivoChecagem = arquivo.FileName.Split(".");
            string extensaoArquivo = arquivoChecagem[1];

            if (arquivo == null || arquivo.Length == 0 || arquivo.Length > 200000000)
            {
                return new ValidadorArquivo() { Status = false, Mensagem = "Erro ao subir arquivo. Tamanho não suportado." };
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "Content/Images", imgNome);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            if (Extensao(extensaoArquivo))
                return new ValidadorArquivo() { Status = true, Mensagem = "Arquivo enviado com sucesso!" };

            else return new ValidadorArquivo() { Status = false, Mensagem = "Erro ao subir arquivo. Extensão não suportada." };
        }
    }
}
