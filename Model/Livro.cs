    public class Livro
    {
        //[NameAttribute("titulo")]
        //[Index(0)]
        public string Titulo { get; set; }
        
        //[Name("autor")]
        //[Index(2)] 
        public string Autor { get; set; }

        //[Name("preço")]
        //[Index(1)]
        public decimal Preco { get; set; }

        //[Name("lançamento")]
        //[Index(3)]
        //[Format ("dd/mm/yyyy")]
        public DateOnly Lancamento { get; set; }

    }
