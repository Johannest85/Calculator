using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ExceptionServices;





class Stringifier: IVisitor {
   public Stringifier(IVisitable t) {
      s = new StringBuilder();
      t.Accept(this);
   }
   public void Visit(Literal e) {
      s.Append(e.Value);
   }
   public void Visit(Add e) {
      s.Append("(");
      e.Left.Accept(this);
      s.Append("+");
      e.Right.Accept(this);
      s.Append(")");
   }
   public void Visit(Mul e) {
      e.Left.Accept(this);
      s.Append("*");
      e.Right.Accept(this);
   }
  public void Visit(Div e)
{  
    e.Left.Accept(this);
    s.Append("/");
    e.Right.Accept(this);
    
}

public void Visit(Fct e)
{
    s.Append("(");
    e.Expr.Accept(this);
    s.Append(")!");
}

public void Visit(Max e)
{
   s.Append("max{");
   bool first = true;

    foreach (var arg in e)
   {
      if (!first) s.Append(",");
      arg.Accept(this);
      first = false;
   }

   s.Append("}");
      
}
   public void Clear() => s.Clear();
   public override string ToString() => s.ToString();
   private StringBuilder s;
}