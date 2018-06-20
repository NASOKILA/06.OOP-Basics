using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class PriceCalcultor
{
    private decimal price;
    private int days;
    private Seasons season;
    private DiscountType discountType;
    
    public PriceCalcultor()
    {}
    
    public PriceCalcultor(string input)
    {
        var info = input.Split().ToArray();

        price = decimal.Parse(info[0]);
        days = int.Parse(info[1]);

        //PASRVAME STRINGOVETE KUM ENUMITE KOITO SME NAPRAVILI
        season = Enum.Parse<Seasons>(info[2]);
        discountType = DiscountType.None;
        
        if (info.Length > 3)
            discountType = Enum.Parse<DiscountType>(info[3]);
    }

    public string CalculateTotalPrice()
    {
            
        decimal result = (days * price) * (int)season;
        decimal discountPercentage = ((decimal)100 - (int)discountType) / 100;
        result = result * discountPercentage;

        return result.ToString("F2");
    }


}






