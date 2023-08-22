namespace Cadastro_Usuario.Helper
{
    public interface IEmail
    {
        bool Enviar(string email, string assunto, string mensagem);

    }
}
