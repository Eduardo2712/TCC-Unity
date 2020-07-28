using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;

public class BancoDeDados : MonoBehaviour
{
    private IDbConnection connection;
    private IDbCommand command;
    private IDataReader reader;

    private string dbFile = "URI=File:MySQLiteDB.db";

    void Start()
    {
        Connection();
        //Insert();
        ConsultAll();
    }

    private void Connection()
    {
        connection = new SqliteConnection(dbFile);
        command = connection.CreateCommand();
        connection.Open();
        string testTable = "CREATE TABLE IF NOT EXISTS paciente(id INTEGER PRIMARY KEY AUTOINCREMENT, idExercicio INT, nome VARCHAR(30));";
        command.CommandText = testTable;
        command.ExecuteNonQuery();
    }

    public void Insert()
    {
        string query = "INSERT INTO paciente(idExercicio, nome) VALUES(2, 'Eduardo')";
        command.CommandText = query;
        command.ExecuteNonQuery();
    }

    public void UpdateColumn()
    {
        int id = 1;
        string novoNome = "Eduardo";
        string query = "SELECT * FROM paciente WHERE id = " + id + ";";
        command.CommandText = query;
        reader = command.ExecuteReader();
        while (reader.Read())
        {
            int idPaciente = reader.GetInt32(0);
            int idExercicio = reader.GetInt32(1);
            string nome = reader.GetString(2);
            Debug.Log("idPaciente: " + idPaciente + " idExercicio: " + idExercicio + " nome: " + nome);
        }
        query = "UPDATE paciente SET nome = " + novoNome + "WHEREN id = " + id + ";";
        command.CommandText = query;
        command.ExecuteNonQuery();
    }

    public void InsertOrUpdate()
    {

    }

    public void ConsultOne()
    {
        int id = 1;
        string query = "SELECT *FROM paciente WHERE id = " + id + ";";
        command.CommandText = query;
        reader = command.ExecuteReader();
        while(reader.Read())
        {
            int idPaciente = reader.GetInt32(0);
            int idExercicio = reader.GetInt32(1);
            string nome = reader.GetString(2);
            Debug.Log("idPaciente: " + idPaciente + " idExercicio: " + idExercicio + " nome: " + nome);
        }
    }

    public void ConsultAll()
    {
        string query = "SELECT * FROM paciente;";
        command.CommandText = query;
        reader = command.ExecuteReader();
        while (reader.Read())
        {
            int idPaciente = reader.GetInt32(0);
            int idExercicio = reader.GetInt32(1);
            string nome = reader.GetString(2);
            Debug.Log("idPaciente: " + idPaciente + " idExercicio: " + idExercicio + " nome: " + nome);
        }
    }

    public void Delete()
    {
        int id = 1;
        string query = "DELETE FROM paciente WHERE id = " + id + ";";
        command.CommandText = query;
        command.ExecuteNonQuery();

    }
}
