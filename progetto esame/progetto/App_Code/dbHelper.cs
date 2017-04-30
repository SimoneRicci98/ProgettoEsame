using System;
using System.Data.OleDb;

public class dbHelper
{
    string nomeDb;
    OleDbConnection connDb;
    OleDbCommand istruzioneSQL;

	public dbHelper(string nomeDb) //costruttore con parametro
	{

        connDb=new OleDbConnection();
        this.nomeDb = nomeDb;

	}
    public void setNomeDb(string nomeDb)
    {
        this.nomeDb=nomeDb;
    } //costruttore senza parametro

    public void connetti()
    {
        connDb.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|" + nomeDb + ";";
     connDb.Open();

      
    } //metodo di connessione
    public void disconnetti()
    {
        connDb.Close();
    } //metodo di disconnessione

    public void assegnaComando(string istruzione) //istruzione di comando SQL
    {
        istruzioneSQL=new OleDbCommand();
        istruzioneSQL.CommandText = istruzione;
        istruzioneSQL.Connection = connDb;
    }

    public OleDbDataReader estraiDati()
    {
        OleDbDataReader rsDati;
       
        rsDati = istruzioneSQL.ExecuteReader();

        return rsDati;
    }
    public void eseguicomando()
    {
        istruzioneSQL.ExecuteNonQuery();
    }

}
