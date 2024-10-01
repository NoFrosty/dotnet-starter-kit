namespace FSH.Starter.WebApi.Math.Domain;
public class RankItem
{
    public RankItem(string userName, int score)
    {
        UserName = userName;
        Score = score;
    }

    public string UserName { get; set; }

    public int Score { get; set; }

}
