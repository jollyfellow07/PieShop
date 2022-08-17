namespace PieShop.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; } //mi restituisce tutte le torte nell implementazione
        IEnumerable<Pie> PiesOfTheWeek { get; } //nella classe pie abbiamo le torte della settimana in boolean non nullable
        Pie? GetPieById(int pieId);  //qui passo il pieId e eventualmente mi restituisce la torta con quell id
        IEnumerable<Pie> SearchPies(string searchQuery);
    }
}
