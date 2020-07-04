namespace Api.Models.Response
{
    public class ErroResponse
    {
        public int Codigo { get; set; }
        public string Erro { get; set; }

        public ErroResponse(int codigo, string erro)
        {
            this.Codigo = codigo;
            this.Erro = erro;
        }
    }
}