using System;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;
using PagseguroPlugPlay_API.Classes;

// ReSharper disable UnusedMember.Local
// ReSharper disable All

namespace PagseguroPlugPlay_API.Forms
{
    public partial class frm_Pagamento : Form
    {
        #region Propriedades, struct e metodos externos da dll do pagseguro

        public static int waitResp;
        public static byte[] amount = new byte[12];
        public const string COMPORT = "COM4";
        private string codigoTransacao = " ";
        private int codResposta = 0;

        [StructLayout(LayoutKind.Sequential)]
        public struct result
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 65542 + 1)]
            public string rawBuffer;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1023 + 1)]
            public string message;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32 + 1)]
            public string transactionCode;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10 + 1)]
            public string date;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8 + 1)]
            public string time;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12 + 1)]
            public string hostNsu;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30 + 1)]
            public string cardBrand;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6 + 1)]
            public string bin;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4 + 1)]
            public string holder;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10 + 1)]
            public string userReference;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 65 + 1)]
            public string terminalSerialNumber;
        }

        /// <summary>
        /// Metodo que inicializa a conexão com a moderninha pro via bluetooth
        /// </summary>
        /// <param name="comport">porta de conexão com a maquina</param>
        /// <returns>retorna um codigo de mensagem, todos codigos estao na documentacao do pagseguro</returns>
        [DllImport("PPPagSeguro.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int InitBTConnection(byte[] comport);

        /// <summary>
        /// Seta a versão do aplicativo
        /// </summary>
        /// <param name="appName">Nome do aplicativo (pode ser o nome da sua empresa)</param>
        /// <param name="version">Versão do aplicativo (ex: 0.0.1)</param>
        /// <returns>retorna um codigo de mensagem, todos codigos estao na documentacao do pagseguro</returns>
        [DllImport("PPPagSeguro.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int SetVersionName(
            byte[] appName,
            byte[] version
        );

        /// <summary>
        /// Cancela uma transação (estorno)
        /// </summary>
        /// <param name="transactionResult"></param>
        /// <returns>retorna um codigo de mensagem, todos codigos estao na documentacao do pagseguro</returns>
        [DllImport("PPPagSeguro.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int CancelTransaction(
            IntPtr transactionResult
        );

        /// <summary>
        /// Retorna o status da ultima transaçao
        /// </summary>
        /// <param name="transactionResult"></param>
        /// <returns>retorna um codigo de mensagem, todos codigos estao na documentacao do pagseguro</returns>
        [DllImport("PPPagSeguro.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int GetLastApprovedTransactionStatus(
            IntPtr transactionResult
        );

        /// <summary>
        /// Pega a versao da biblioteca
        /// </summary>
        /// <returns>retorna um codigo de mensagem, todos codigos estao na documentacao do pagseguro</returns>
        [DllImport("PPPagSeguro.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int GetVersionLib();

        /// <summary>
        /// Metodo que faz a maquininha efetuar a solicitacao de pagamento, o core do sistema, dependendo dos parametros pode ser credito, debito, voucher...
        /// </summary>
        /// <param name="paymentMethod">1 = credito, 2 = debito, 3 = voucher</param>
        /// <param name="installmenttype">1 = a vista, 2 = parcelado</param>
        /// <param name="installments">quantidade de parcelas, coloque 1 se for a vista</param>
        /// <param name="amount">valor da compra</param>
        /// <param name="userreference">codigo da venda</param>
        /// <param name="transactionResult">pointer de memoria da transacao</param>
        /// <returns>retorna um codigo de mensagem, todos codigos estao na documentacao do pagseguro</returns>
        [DllImport("PPPagSeguro.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int SimplePaymentTransaction(
            int paymentMethod,
            int installmenttype,
            int installments,
            byte[] amount,
            byte[] userreference,
            IntPtr transactionResult
        );

        #endregion Propriedades, struct e metodos externos da dll do pagseguro

        public frm_Pagamento()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metodo que converte o valor da compra para bytes
        /// </summary>
        /// <param name="_buff">Pointer para address de memoria do valor total</param>
        /// <param name="_valorTotalCompra">Valor total da compra</param>
        private unsafe void ConverterParaBytes(byte* _buff, int _valorTotalCompra)
        {
            //for de 12 casas por causa do format.
            string str = String.Format("{0:000000000000}", _valorTotalCompra);
            for (int i = 0; i < 12; i++)
                unsafe
                {
                    //_buff é o endereço de "enderecoValor" na chamada desse metodo ou seja, o valor que esta sendo colocado aqui dentro de _buff[i] vai diretamente para o endereço de "enderecoValor" que é o mesmo endereço de amount (na chamada desse metodo)
                    _buff[i] = (byte)Convert.ToInt16(str[i]);
                }
        }

        private void btnVerComprovante_Click(object sender, EventArgs e)
        {
            BuscarComprovanteApiPagSeguro();
        }

        /// <summary>
        /// Metodo que faz a busca do comprovante de transacao via API com o codigo de transacao
        /// </summary>
        /// <returns></returns>
        private async Task BuscarComprovanteApiPagSeguro()
        {
            try
            {
                //if (true)
                if (codigoTransacao != " ")
                {
                    HttpClient client = new HttpClient { BaseAddress = new Uri($"https://ws.pagseguro.uol.com.br/v2/transactions/{codigoTransacao}?email=cleisonuzumak@hotmail.com&token=02df6ac0-437d-49bd-b3d9-167c02986a54327475ea4169a8b7df9708f4f4b4af10bf16-00ab-4eb3-b3fc-bf7c80ba9879") };
                    //HttpClient client = new HttpClient { BaseAddress = new Uri($"https://ws.pagseguro.uol.com.br/v2/transactions/551358D5-612E-4350-ACB4-B65D1FBCA33A?email=cleisonuzumak@hotmail.com&token=02df6ac0-437d-49bd-b3d9-167c02986a54327475ea4169a8b7df9708f4f4b4af10bf16-00ab-4eb3-b3fc-bf7c80ba9879") };
                    HttpResponseMessage response = await client.GetAsync(string.Empty);
                    string content = await response.Content.ReadAsStringAsync();

                    XmlDocument xmlText = new XmlDocument();
                    xmlText.LoadXml(content);

                    string jsonText = JsonConvert.SerializeXmlNode(xmlText);
                    //dynamic JsonDeserialized = JsonConvert.DeserializeObject(jsonText);

                    Moderninha jsonTratado = JsonConvert.DeserializeObject<Moderninha>(jsonText);

                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine($"Status: {VerificarStatusTransacao(jsonTratado.Transaction.Status)}");
                    sb.AppendLine();
                    sb.AppendLine("TRANSAÇÃO ------ ");
                    sb.AppendLine($"Código da transação: {jsonTratado.Transaction.Code}");
                    sb.AppendLine($"Data da criação: {jsonTratado.Transaction.Date}");
                    sb.AppendLine($"Código da venda: {jsonTratado.Transaction.DeviceInfo.Reference}");
                    sb.AppendLine($"Valor: { jsonTratado.Transaction.GrossAmount}");
                    sb.AppendLine($"Taxas: {jsonTratado.Transaction.FeeAmount}");
                    sb.AppendLine($"Total (líquido): {jsonTratado.Transaction.NetAmount}");
                    sb.AppendLine($"Tipo meio de pagamento: {VerificarMeioPagamento(jsonTratado.Transaction.PaymentMethod.Type)}");
                    sb.AppendLine($"Quantidade parcelas: {jsonTratado.Transaction.InstallmentCount}");
                    sb.AppendLine($"Codigo meio de pagamento: {jsonTratado.Transaction.PaymentMethod.Code}");
                    sb.AppendLine($"Data de crédito: {jsonTratado.Transaction.EscrowEndDate}"); //Data que o valor estara na conta do vendedor
                    sb.AppendLine();
                    sb.AppendLine("ITEM ------ ");
                    sb.AppendLine($"Id: {jsonTratado.Transaction.Items.Item.Id}");
                    sb.AppendLine($"Valor unitario: {jsonTratado.Transaction.Items.Item.Amount}");
                    sb.AppendLine($"Descricao: {jsonTratado.Transaction.Items.Item.Description}");
                    sb.AppendLine($"Quantidade: {jsonTratado.Transaction.Items.Item.Quantity}");

                    MessageBox.Show($"{sb}");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"ERRO: {e}");
            }
        }

        private string VerificarStatusTransacao(string _codigoStatus)
        {
            switch (_codigoStatus)
            {
                case "1":
                    return "Aguardando pagamento.";

                case "2":
                    return "Em análise.";

                case "3":
                    return "Paga.";

                case "4":
                    return "Disponível.";

                case "5":
                    return "Em disputa.";

                case "6":
                    return "Devolvida.";

                case "7":
                    return "Cancelada.";

                default:
                    return "ERRO.";
            }
        }

        private string VerificarMeioPagamento(string _codigoPagamento)
        {
            switch (_codigoPagamento)
            {
                case "1":
                    return "Cartão de crédito.";//o comprador escolheu pagar a transação com cartão de crédito.

                case "2":
                    return "Boleto.";//o comprador optou por pagar com um boleto bancário.

                case "3":
                    return "Débito online (TEF).";// o comprador optou por pagar a transação com débito online de algum dos bancos conveniados.

                case "4":
                    return "Saldo PagSeguro.";//o comprador optou por pagar a transação utilizando o saldo de sua conta PagSeguro.

                case "5":
                    return "Oi Paggo.";//o comprador escolheu pagar sua transação através de seu celular Oi.

                case "7":
                    return "Depósito em conta.";//o comprador optou por fazer um depósito na conta corrente do PagSeguro. Ele precisará ir até uma agência bancária, fazer o depósito,
                                                //guardar o comprovante e retornar ao PagSeguro para informar os dados do pagamento. A transação será confirmada somente após a finalização deste processo,
                                                //que pode levar de 2 a 13 dias úteis.

                case "8":
                    return "Cartão de débito";//o comprador escolheu pagar a transação com cartão de débito.

                default:
                    return "ERRO.";
            }
        }

        private void frm_Pagamento_Load(object sender, EventArgs e)
        {
            var task = Task.Run(() =>
            {
                EfetuarTransacao();
            });

            var awaiter = task.GetAwaiter();

            awaiter.OnCompleted(() =>
            {
                lblStatusMaquininha.Text = codigoTransacao;

                lblCodigoResposta.Text = codResposta.ToString();
                lblCodigoResposta.Left = (this.Width / 2) - (lblCodigoResposta.Width / 2);
            });
        }

        /// <summary>
        /// Metodo core do sistema, ele que é responsavel por conectar com a maquina e efetuar
        /// a transação, seja ela pagamento via debito, credito ou estorno.
        /// </summary>
        public void EfetuarTransacao()
        {
            try
            {
                unsafe
                {
                    //enderecoValor = Armazena o endereco da variavel amount
                    fixed (byte* enderecoValor = amount)
                    {
                        ConverterParaBytes(enderecoValor, frm_Inicial.vlTotal);
                    }
                }

                int codigoRetorno = 0;

                if (frm_Inicial.vlTotal != 0)
                {
                    result trsResult = new result();
                    byte[] comport = Encoding.ASCII.GetBytes(COMPORT); //Retorna a porta bluetooh (COM4 nesse caso)
                    byte[] codvenda = Encoding.ASCII.GetBytes("Coxinha"); //Pega o codigo da venda que nada mais é que o item vendido nesse caso

                    int size = Marshal.SizeOf(trsResult); //Tamanho em bytes de memoria do objeto
                    IntPtr ptr = Marshal.AllocHGlobal(size); //Aloca espaco na memoria com o tamanho exato de bytes que foi pego na linha anterior
                    Marshal.StructureToPtr(trsResult, ptr, false); //Aparentemente pega os dados da struct e coloca dentro do endereco de memoria.

                    byte[] appName = Encoding.ASCII.GetBytes("Salgados James"); //Nome do aplicativo (Obrigatorio)
                    byte[] version = Encoding.ASCII.GetBytes("0.0.1"); //Versao do aplicativo (Obrigatorio)
                    SetVersionName(appName, version); //Seta nome e versao na api da maquina (Obrigatorio)

                    switch (frm_Inicial.tipoPagamento)
                    {
                        case 0:
                            try
                            {
                                codigoRetorno = InitBTConnection(comport);
                                codigoRetorno = CancelTransaction(ptr);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"CASE 0 - Erro: {ex}");
                            }

                            break;

                        case 1:
                            try
                            {
                                codigoRetorno = InitBTConnection(comport);
                                codigoRetorno = SimplePaymentTransaction(1, 1, 1, amount, codvenda, ptr);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"CASE 1 - Erro: {ex}");
                            }

                            break;

                        case 2:

                            try
                            {
                                InitBTConnection(comport);
                                codigoRetorno = SimplePaymentTransaction(2, 1, 1, amount, codvenda, ptr);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"CASE 2 - Erro: {ex}");
                            }

                            break;
                    }

                    trsResult = (result)Marshal.PtrToStructure(ptr, typeof(result));
                    codigoTransacao = trsResult.transactionCode;

                    codResposta = codigoRetorno;

                    Marshal.FreeHGlobal(ptr); //Libera memoria que anteriormente foi armazenada pra guardar os dados

                    frm_Inicial.ConfirmaPagamento = codigoRetorno;
                }
                else
                {
                    frm_Inicial.ConfirmaPagamento = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Form load event - Erro: {ex}");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}