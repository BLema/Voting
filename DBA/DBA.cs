using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System;

namespace Voting
{
    class DBA
    {
        //private static string candidateDir = @"C:\Users\..\documents\visual studio 2015\Projects\Voting\Voting";
        private static string dir = Directory.GetCurrentDirectory();
        private static string candidatePath = dir + @"\Candidates.txt";
        private static SqlConnection con = new SqlConnection(Properties.Settings.Default.BallotsConnectionString1);

        public static List<string> getCandidates()
        {
            List<string> candidates = new List<string>();
            if (Directory.Exists(dir))
            {
                StreamReader textIn = new StreamReader(new FileStream(candidatePath, FileMode.OpenOrCreate, FileAccess.Read));
    
                while (textIn.Peek() != -1)
                {
                    candidates.Add(textIn.ReadLine());
                }
                textIn.Close();
            }

            return candidates;
        }

        public static bool castBallot(Ballot ball)
        { 
            string insert = "INSERT Ballots VALUES (@candidate1, " +
                "@candidate2, @candidate3, @candidate4)";

            SqlCommand insertCommand = new SqlCommand(insert, con);
            insertCommand.CommandType = CommandType.Text;
            insertCommand.Parameters.AddWithValue("@candidate1", ball.Candidates[0]);
            insertCommand.Parameters.AddWithValue("@candidate2", ball.Candidates[1]);
            insertCommand.Parameters.AddWithValue("@candidate3", ball.Candidates[2]);
            insertCommand.Parameters.AddWithValue("@candidate4", ball.Candidates[3]);

            int count = 0;
            try
            {
                con.Open();
                count = insertCommand.ExecuteNonQuery();
            }
            catch (SqlException ex) { throw ex; }
            finally { con.Close(); }

            return count > 0;
        }

        public static List<Ballot> getBallots()
        {
            string select = "SELECT * FROM Ballots";

            SqlCommand selectCommand = new SqlCommand(select, con);

            List<Ballot> ballots = new List<Ballot>();

            try
            {
                con.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Ballot ball = new Ballot(reader["Candidate1"].ToString(), 
                        reader["Candidate2"].ToString(), 
                        reader["Candidate3"].ToString(), 
                        reader["Candidate4"].ToString());
                    ballots.Add(ball);
                }
            }
            catch(SqlException ex) { throw ex; }
            finally { con.Close(); }

            return ballots;
        }

        public static List<Candidate> getCandidateVotes()
        {
            List<Candidate> candidates = new List<Candidate>();
            List<string> candidateNames = getCandidates();
            string select;
            SqlCommand selectCommand;
            SqlDataReader reader;
            foreach(string cn in candidateNames)
            {
                Candidate c = new Candidate(cn);
                select = "Select A.C as 'One', B.C as 'Two', C.C as 'Three', D.C as 'Four' " +
                    "FROM (Select Count(*) as 'C' From Ballots where Candidate1 = @cand) A, " +
                    "(Select Count(*) as 'C' from Ballots where Candidate2 = @cand) B, "+
                    "(Select Count(*) as 'C' from Ballots where Candidate3 = @cand) C, "+
                    "(Select Count(*) as 'C' from Ballots where Candidate4 = @cand) D;";
                selectCommand = new SqlCommand(select, con);
                selectCommand.Parameters.AddWithValue("@cand", cn);
                con.Open();
                reader = selectCommand.ExecuteReader();
                reader.Read();
                c.setVotes(Convert.ToInt32(reader["One"]), Convert.ToInt32(reader["Two"]), 
                    Convert.ToInt32(reader["Three"]), Convert.ToInt32(reader["Four"]));
                con.Close();
                
                candidates.Add(c);
            }
            return candidates;
        }
        public static List<Candidate> getCandidateFirstVotes()
        {
            List<Candidate> candidates = new List<Candidate>();
            List<string> candidateNames = getCandidates();
            string select;
            SqlCommand selectCommand;
            SqlDataReader reader;
            foreach (string cn in candidateNames)
            {
                Candidate c = new Candidate(cn);
                
                select = "SELECT Count(*) as \"COUNT\" FROM Ballots WHERE Candidate1 = '" + cn + "';";
                selectCommand = new SqlCommand(select, con);
                con.Open();
                reader = selectCommand.ExecuteReader();
                reader.Read();
                c.First = Convert.ToInt32(reader["COUNT"]);
                con.Close();

                candidates.Add(c);
            }
            return candidates;
        }

        public static List<Candidate> getCandidateNextVotes(List<Candidate> remaining, Stack<Candidate> eliminated)
        {
            string select;
            SqlCommand selectCommand;
            SqlDataReader reader;
            Candidate[] elim = new Candidate[eliminated.Count];
            eliminated.CopyTo(elim, 0);

            foreach (Candidate cn in remaining)
            {
                switch (elim.Length)
                {
                    case 1:
                    {
                        select = "SELECT Count(*) as \"COUNT\" FROM Ballots "+ 
                                "WHERE Candidate1 = '" + elim[0].Name + 
                                "' AND Candidate2 = '" + cn.Name + "';";
                        selectCommand = new SqlCommand(select, con);
                        con.Open();
                        reader = selectCommand.ExecuteReader();
                        reader.Read();
                        cn.Second = Convert.ToInt32(reader["COUNT"]);
                        con.Close();
                        break;
                    }
                    case 2:
                    {
                        select = "SELECT Count(*) as \"COUNT\" FROM Ballots " +
                                "WHERE (Candidate1 = @cand2 and Candidate2 = @this) " +
                                "OR (((Candidate1 = @cand1 and Candidate2 = @cand2) "+
                                "OR (Candidate1 = @cand2 and Candidate2 = @cand1)) AND Candidate3 = @this);";
                          
                        selectCommand = new SqlCommand(select, con);
                        selectCommand.Parameters.AddWithValue("@this", cn.Name);
                        selectCommand.Parameters.AddWithValue("@cand1", elim[1].Name);
                        selectCommand.Parameters.AddWithValue("@cand2", elim[0].Name);
                        con.Open();
                        reader = selectCommand.ExecuteReader();
                        reader.Read();
                        cn.Third = Convert.ToInt32(reader["COUNT"]);
                        con.Close();
                        break;
                    }
                    case 3:
                    {
                        select = "SELECT Count(*) as \"COUNT\" FROM Ballots " +
                                "WHERE (Candidate1 = @cand3 and Candidate2 = @this) " +
                                "OR ((Candidate1 = @cand1 OR Candidate1 = @cand2) and Candidate2 = @cand3 and Candidate3 = @this) " +
                                "OR (Candidate1 = @cand3 AND (Candidate2 = @cand1 OR Candidate2 = @cand2) and Candidate3 = @this) " +
                                "OR (Candidate1 = @cand3 and (Candidate2 = @cand1 OR Candidate2 = @cand2) and (Candidate3 = @cand2 OR Candidate3 = @cand1) AND Candidate4 = @this)" +
                                "OR ((Candidate1 = @cand1 OR Candidate1 = @cand2) and Candidate2 = @cand3 and (Candidate3 = @cand2 OR Candidate3 = @cand1) AND Candidate4 = @this)" +
                                "OR ((Candidate1 = @cand1 OR Candidate1 = @cand2) and (Candidate2 = @cand2 OR Candidate2 = @cand1) and Candidate3 = @cand3 AND Candidate4 = @this)" +
                                ";";

                        selectCommand = new SqlCommand(select, con);
                        selectCommand.Parameters.AddWithValue("@this", cn.Name);
                        selectCommand.Parameters.AddWithValue("@cand1", elim[2].Name);
                        selectCommand.Parameters.AddWithValue("@cand2", elim[1].Name);
                        selectCommand.Parameters.AddWithValue("@cand3", elim[0].Name);
                        con.Open();
                        reader = selectCommand.ExecuteReader();
                        reader.Read();
                        cn.Fourth = Convert.ToInt32(reader["COUNT"]);
                        con.Close();
                        break;
                    }
                    default:
                        break;
                }
            }
            return remaining;
        }
    }
}
