namespace WpfDesignerAss
{
    using System;
    
    [Flags]
    public enum CourseType : int
    {
        WPF = 1,
        CSharp = 2,
        OOP = 4,
        ADO = 8,
        MAUI = 16,
        SQL = 32,
        JS = 64
    }
}