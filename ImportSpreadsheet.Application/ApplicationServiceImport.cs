using AutoMapper;
using ImportSpreadsheet.Application.Dtos;
using ImportSpreadsheet.Application.Interfaces;
using ImportSpreadsheet.Domain.Core.Interfaces.Services;
using ImportSpreadsheet.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace ImportSpreadsheet.Application
{
    public class ApplicationServiceImport : IApplicationServiceImport
    {
        private readonly IServiceImport serviceImport;
        private readonly IMapper mapper;
        public ApplicationServiceImport(IServiceImport serviceImport
                                       , IMapper mapper)
        {
            this.serviceImport = serviceImport;
            this.mapper = mapper;
        }
        public object ImportSpredSheet(string directory)
        {
            string strConexao = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + directory + ".xlsx" + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
            OleDbConnection conn = new OleDbConnection(strConexao);
            conn.Open();

            try
            {
                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                //DataSet dtsExcel = new DataSet();
                List<string> HeaderData = new List<string>();

                foreach (DataRow row in dt.Rows)
                {
                    // Obtem o nome da Aba da Planilha
                    string Aba = row["TABLE_NAME"].ToString();

                    // obtem todos as linhas da planilha corrente
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + Aba + "]", conn);
                    cmd.CommandType = CommandType.Text;

                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // colocar o nome da aba da planilha
                        if (Aba == "Questionario$")
                        {
                            HeaderData.Add(
                                "Objeto:" + reader["Objeto"].ToString() + ";" +
                                "Cargo:" + reader["Cargo"].ToString() + ";" +
                                "PerguntaAtual:" + reader["PerguntaAtual"].ToString() + ";" +
                                "PerguntaNova:" + reader["PerguntaNova"].ToString() + ";"
                                );
                        }
                        else
                        {
                            return new { Mensagem = string.Format("Planilha fora do formato permitido para a Importação") };
                        }
                    }

                }

                IList<SpreadSheetDTO> SpreadSheetClass = new List<SpreadSheetDTO>();
                IList<LogsDTO> Logs = new List<LogsDTO>();

                var nCount = 0;
                string LogErro = "";
                int nErro = 0;

                foreach (string objSpreadSheet in HeaderData)
                {
                    nErro = 0;
                    string[] separador = objSpreadSheet.Split(';');
                    // responsável por armazenar todos os erros que for encontrado de acordo com a regra de negócio estabelicida para os campos da planilha
                    LogErro = string.Empty;

                    SpreadSheetClass.Add(new SpreadSheetDTO { });

                    foreach (string arrayPlanilha in separador)
                    {
                        if (arrayPlanilha.Contains("Objeto"))
                        {
                            var valor = arrayPlanilha.Substring(arrayPlanilha.IndexOf(":") + 1);
                            SpreadSheetClass[nCount].Objeto = valor;

                        }

                        if (arrayPlanilha.Contains("Cargo"))
                        {
                            var valor = arrayPlanilha.Substring(arrayPlanilha.IndexOf(":") + 1);
                            SpreadSheetClass[nCount].Cargo = valor;

                            // verificar se o cargo existe

                        }

                        if (arrayPlanilha.Contains("PerguntaAtual"))
                        {
                            var valor = arrayPlanilha.Substring(arrayPlanilha.IndexOf(":") + 1);
                            SpreadSheetClass[nCount].PerguntaAtual = valor;

                        }

                        if (arrayPlanilha.Contains("PerguntaNova"))
                        {
                            var valor = arrayPlanilha.Substring(arrayPlanilha.IndexOf(":") + 1);
                            SpreadSheetClass[nCount].PerguntaNova = valor;

                        }

                        SpreadSheetClass[nCount].Errors = LogErro;

                    }
                    nCount++;

                }

                if (SpreadSheetClass.Count() > 0)
                {
                    var Data = DateTime.Now;
                    var j = 0;

                    foreach (var InsertSheet in SpreadSheetClass)
                    {
                        Logs.Add(new LogsDTO
                        { });

                        if (!string.IsNullOrEmpty(InsertSheet.Errors))
                        {
                            Logs[j].Pergunta = InsertSheet.PerguntaAtual;
                            Logs[j].Status = "Não importado!";
                            Logs[j].Error = "Motivo do Erro";


                        }
                        else
                        {
                            // crio os inserts 
                        }
                        j++;
                    }
                }
                return Logs;

            }
            catch (Exception ex)
            {
                return new
                {
                    Mensagem = "Erro ao Importar Planilha:" + ex.Message
                };
            }
        }

    }
}
