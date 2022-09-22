namespace cadastro_remedios
{
    public class Credentials
    {
        public const string lAdress = "gnascimentosantos@hotmail.com";
        public const string lGerenciaAdress = "gerencia.farmalife@gmail.com";
        public const string lPassword = "JordanLebron23";
        public const string lSmtpLive = "smtp.live.com";
        public const string lSmtpGmail = "smtp.gmail.com";
        public const int lSmtpLivePort = 587;
        public const string lAdminUsername = "admin";
        public const string lAdminPassword = "admin";

    }
	public class Connection
    {
        public const string lConnection = "Server=127.0.0.1;DATABASE=farmalife;UID=root;PASSWORD=123";
    }

    public class MessageBoxResult
    {
        public const string lSucess = "Cadastrado com sucesso!";
        public const string lError = "Erro ao cadastrar!";
        public const string lErrorUpdate = "Erro ao alterar!";
        public const string lUpdate = "Alterado com sucesso!";
        public const string lStockError = "O estoque não possui está quantidade!";
        public const string lErrorCommand = "Erro de Comandos!";
        public const string lEmailError = "Falha ao enviar e-mail";
        public const string lExportError = "Erro ao exportar arquivo";
        public const string lDeleteError = "Erro ao deletar registros";


    }
    public class Errors
    {
        public const string lZipCodeInvalid = "Cep não é valido!";
    }

    public class Config
    {
        public const int lEnterValue = 13;
        public const string lAlert = "Alerta";
        public const string lRequired = " é obrigatório.";
        public const string lFied = "O campo ";
        public const string lErrorRegister = "Campos obrigatórios não foram preenchidos.";
        public const string lDelete = "Registros Deletados";
    }
}
