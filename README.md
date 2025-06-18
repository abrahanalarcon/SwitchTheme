## Documentation


Esta app crea  dos temas (claro/oscuro) usando DynamicResource y un Switch para alternarlos.


[Resource dictionaries](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/resource-dictionaries?view=net-maui-9.0)
[DynamicResource](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.xaml.dynamicresourceextension?view=net-maui-9.0)
## Estructura 

SwitchTheme/
├── Resources/
│   ├── Styles/
│   │   ├── Colors.xaml       # Definiciones de colores
│   │   └── Styles.xaml       # Estilos globales
├── MainPage.xaml             # Vista principal
├── MainPage.xaml.cs          # Lógica de la vista
├── App.xaml                  # Recursos de aplicación
└── App.xaml.cs               # Punto de entrada


## Implementación del Cambio de Tema

El núcleo de la funcionalidad de cambio de tema se encuentra en el método `ApplyTheme`:

```csharp
private void ApplyTheme(bool darkMode)
{
    var resources = Application.Current.Resources;
    
    if (darkMode)
    {
        resources["DynamicPrimaryColor"] = resources["PrimaryColorDark"];
        resources["DynamicSecondaryColor"] = resources["SecondaryColorDark"];
        resources["DynamicTextColor"] = resources["TextColorDark"];
        resources["DynamicBackgroundColor"] = resources["BackgroundColorDark"];
    }
    else
    {
        resources["DynamicPrimaryColor"] = resources["PrimaryColor"];
        resources["DynamicSecondaryColor"] = resources["SecondaryColor"];
        resources["DynamicTextColor"] = resources["TextColor"];
        resources["DynamicBackgroundColor"] = resources["BackgroundColor"];
    }
}
```

**Funcionamiento:**
1. Accede a los recursos globales de la aplicación
2. Según el modo seleccionado (`darkMode` true/false):
   - Reemplaza los recursos dinámicos con las paletas oscura/clara
3. Todos los elementos que usen `DynamicResource` se actualizarán automáticamente

## Lógica de Cambio de Tema

```csharp
private void ApplyTheme(bool darkMode)
{
    var resources = Application.Current.Resources;
    if (darkMode)
    {
        resources["DynamicPrimaryColor"] = resources["PrimaryColorDark"];
        // ...otros recursos
    }
    else
    {
        resources["DynamicPrimaryColor"] = resources["PrimaryColor"];
        // ...otros recursos
    }
}
```

| Modo      | Color Primario       | Color Texto       | Fondo          |
|-----------|----------------------|-------------------|----------------|
| Claro     | `PrimaryColor`       | `TextColor`       | `BackgroundColor` |
| Oscuro    | `PrimaryColorDark`   | `TextColorDark`   | `BackgroundColorDark` |
