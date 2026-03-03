using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ExceptionServices;



class Mul : IVisitable {
   public Mul(IVisitable Left, IVisitable Right) {
      this.Left = Left;
      this.Right = Right;
   }
   public void Accept(IVisitor vtor) => vtor.Visit(this);
   public readonly IVisitable Left, Right;
}

class Add : IVisitable {
   public Add(IVisitable Left, IVisitable Right) {
      this.Left = Left;
      this.Right = Right;
   }
   public void Accept(IVisitor vtor) => vtor.Visit(this);
   public readonly IVisitable Left, Right;
}

class Div : IVisitable
{
     public Div(IVisitable Left, IVisitable Right) {
      this.Left = Left;
      this.Right = Right;
   }
   public void Accept(IVisitor vtor) => vtor.Visit(this);
   public readonly IVisitable Left, Right;

}
 
class Fct : IVisitable
{
    public readonly IVisitable Expr;

    public Fct(IVisitable expr)
    {
        Expr = expr;
    }
    public void Accept(IVisitor vtor) => vtor.Visit(this);
}

class  Max : IVisitable , IEnumerable<IVisitable>
{
   public readonly List<IVisitable> Expr;

   public Max(List<IVisitable> expr)
   {
      if (expr == null || expr.Count == 0)
      throw new ArgumentException("passed arguments are not correct");

      Expr = expr;
   }
    public Max(IVisitable[] args) : this(new List<IVisitable>(args)) { }
    public void Accept(IVisitor vtor) => vtor.Visit(this);

    public IEnumerator<IVisitable> GetEnumerator()
   {
       return new MaxItrator(Expr);
   }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
   
}
class FactorialOfNegativeException : ArgumentException
{
    public FactorialOfNegativeException()
        : base("cannot calculate factorial of negatives")
    {
    }
}