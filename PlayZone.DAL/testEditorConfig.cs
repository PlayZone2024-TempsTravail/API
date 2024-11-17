#pragma warning disable CS0169 // Field is never used
#pragma warning disable CS0414 // Field is assigned but its value is never used

namespace PlayZone.DAL
{
    // Classe - devrait être en PascalCase
    internal class testEditorConfig
    {

        // Constante - devrait être en SCREAMING_CAMEL_CASE
        public const string MaxValue = "100";

        // Champ privé - devrait avoir un préfixe '_' et être en camelCase
        private int privateField;

        // Propriété - devrait être en PascalCase
        public int myProperty { get; set; }

        // Méthode - devrait être en PascalCase
        public void my_method()
        {
            var x = 10; // Avertissement
            int y = 20; // Correct

            var result = x + y; // Avertissement
            Console.WriteLine(result);

            Console.WriteLine(privateField); // Avertissement
            Console.WriteLine(this.privateField); // Correct
        }

        // Exemple d'utilisation d'un champ privé correct
        private readonly int _myPrivateField = 42;

        // Constante correcte
        public const string MAX_VALUE = "200";

        // Méthode correcte
        public void MyMethod()
        {
            Console.WriteLine("This is a correctly named method.");
        }

        // Propriété correcte
        public int MyProperty { get; set; }
    }
}
