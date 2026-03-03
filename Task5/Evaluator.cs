using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ExceptionServices;

class Evaluator: IVisitor {
   public Evaluator(IVisitable t) {
      s = new Stack<int>();
      t.Accept(this);
   }
   public void Visit(Literal e) {
      s.Push(e.Value);
   }
   public void Visit(Add e) {
      e.Left.Accept(this);
      int left = s.Pop();
      e.Right.Accept(this);
      int right = s.Pop();
      s.Push(left+right);
   }
   public void Visit(Mul e) {
      e.Left.Accept(this);
      int left = s.Pop();
      e.Right.Accept(this);
      int right = s.Pop();
      s.Push(left*right);
   }

  public void Visit(Div e)
  {
       e.Left.Accept(this);
      int left = s.Pop();
      e.Right.Accept(this);
      int right = s.Pop();
       if (right == 0)
        throw new DivideByZeroException();
      s.Push(left/right);
  }    


    public void Visit(Fct e)
    {
        e.Expr.Accept(this);
        int Value = s.Pop();
        if(Value < 0)
            throw new FactorialOfNegativeException();
        int result = 1;

        for(int i = 2; i <= Value ; i++)
        result *= i;
        
         s.Push(result);
    }
   public void Visit(Max e)
   {
      bool first = true;
      int currentMax = 0;

      foreach(var arg in e)
      {
            arg.Accept(this);
        int value = s.Pop();

        if (first || value > currentMax)
        {
            currentMax = value;
            first = false;
        }
         
      }

      s.Push(currentMax);
      


   }
   


   public void Clear() => s.Clear();
   public override string ToString() => s.Peek().ToString();
   private Stack<int> s;
}
