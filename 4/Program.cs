using System;

namespace _4
{
    class MainApp
    {
        static void Main()
        {
            // Create ConcreteComponent and two Decorators
            ChristmasTree tree = new ChristmasTree();
            DecorationsDecorator d1 = new DecorationsDecorator();
            GarlandLightDecorator d2 = new GarlandLightDecorator();

            // Link decorators
            d1.SetComponent(tree);
            d2.SetComponent(d1);

            d2.Operation();

            // Wait for user
            Console.Read();
        }
    }
    // "Component"
    abstract class Tree
    {
        public abstract void Operation();
    }

    // "ConcreteComponent"
    class ChristmasTree : Tree
    {
        public override void Operation()
        {
            Console.WriteLine("It's Christmas tree!");
        }
    }
    // "Decorator"
    abstract class Decorator : Tree
    {
        protected Tree tree;

        public void SetComponent(Tree tree)
        {
            this.tree = tree;
        }
        public override void Operation()
        {
            if (tree != null)
            {
                tree.Operation();
            }
        }
    }

    // "ConcreteDecoratorA"
    class DecorationsDecorator : Decorator
    {
        private string decorations;

        public override void Operation()
        {
            base.Operation();
            decorations = "bells, candles, snow globes";
            Console.WriteLine("There are " + decorations);
        }
    }

    // "ConcreteDecoratorB" 
    class GarlandLightDecorator : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            GarlandLight();
        }
        void GarlandLight()
        {
            Console.WriteLine("There is luminous garland");
        }
    }
}
