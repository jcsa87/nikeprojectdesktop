# Nike Project Desktop

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-0078D7?style=for-the-badge&logo=windows&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC292B?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

Nike Project Desktop es un sistema integral de punto de venta (POS) y gestión de inventario desarrollado en **C# (Windows Forms)** con conexión a una base de datos **SQL Server**. Está diseñado específicamente para tiendas de ropa deportiva, permitiendo la administración eficiente de productos, ventas, usuarios, clientes y reportes.

## 🚀 Características Principales

El sistema cuenta con una arquitectura dividida en diferentes módulos (UserControls) accesibles desde un menú principal:

*   **👥 Gestión de Usuarios:** Creación, lectura, actualización y baja lógica de usuarios del sistema (Administradores, Vendedores). Control estricto de accesos y roles (ej. un vendedor no puede editar o dar de baja a un cliente).
*   **🤝 Gestión de Clientes:** Mantenimiento (CRUD) completo de la cartera de clientes. Validación de unicidad para DNI (Documento Nacional de Identidad).
*   **📦 Inventario y Productos:** Control de catálogo, categorías, stock y mantenimiento de precios de productos (zapatillas, indumentaria, accesorios).
*   **🛒 Ventas (Punto de Venta):** Interfaz ágil para cargar productos a un ticket de venta y facturar a nombre de un cliente. 
*   **🧾 Facturación:** Generación de comprobantes y facturas de venta.
*   **📊 Reportes:** Generación de métricas de ventas, stock y movimientos para la toma de decisiones.
*   **💾 Backups:** Funcionalidad integrada en el sistema para realizar copias de seguridad de la base de datos SQL Server (`BackUpControl`).

## 🛠️ Tecnologías y Herramientas

*   **Lenguaje:** C# (.NET)
*   **Interfaz Gráfica:** Windows Forms (WinForms)
*   **Base de Datos:** Microsoft SQL Server
*   **Librerías Destacadas:** `Microsoft.Data.SqlClient` para acceso seguro a datos (ADO.NET).
*   **Arquitectura:** Patrón multicapas simplificado (Modelos, UI (Forms/UserControls), y Capa de Datos).

## 📁 Estructura del Proyecto

*   `Auth/`: Manejo de inicio de sesión y persistencia de la sesión del usuario (`SesionUsuario.cs`).
*   `DataAccess/`: Clases orientadas a la conexión y ejecución de consultas SQL (`ClienteData.cs`, `UsuarioData.cs`, `Conexion.cs`).
*   `Forms/`: Ventanas principales del sistema (`FacturaForm`, Formularios contenedores).
*   `Helpers/`: Utilidades para la UI y validaciones (`GridHelper.cs`, validadores de campos).
*   `Models/`: Clases que representan las entidades de negocio (`Usuario.cs`, `Cliente.cs`, etc.).
*   `UserControls/`: Vistas modulares incrustables para cada sección (Productos, Clientes, Ventas, Reportes, etc.).

## ⚙️ Instalación y Configuración

1.  **Clonar el repositorio:**
    ```bash
    git clone https://github.com/tu-usuario/nikeprojectdesktop.git
    cd nikeprojectdesktop
    ```
2.  **Configurar Base de Datos:**
    *   Tener instalado SQL Server.
    *   Ejecutar el script SQL de creación de base de datos (si no está provisto en el repositorio, la estructura principal incluye tablas para `CLIENTE`, `USUARIO`, `PRODUCTO`, `VENTA`, etc.).
3.  **Configurar Cadena de Conexión:**
    *   Abrir el archivo `App.config` y buscar la sección de ConnectionStrings (o bien, actualizar la clase `Conexion.cs` en la carpeta `DataAccess`).
    *   Modificar el `Data Source`, nombre de base de datos y credenciales a su instancia local de SQL Server.
4.  **Compilar y Ejecutar:**
    *   Abrir la solución `nikeproject.sln` con **Visual Studio**.
    *   Restaurar los paquetes NuGet si fuera necesario.
    *   Presionar `F5` o el botón "Iniciar" en Visual Studio.

## 👥 Permisos y Roles (Auth)

El sistema utiliza roles definidos en el enumerador `RolUsuario` para restringir accesos en pantalla:
*   **Administrador:** Acceso total al sistema, altas, bajas, modificación de configuraciones, y eliminación de registros.
*   **Vendedor:** Perfil enfocado en la carga de ventas. Tiene capacidades limitadas para modificar registros clave del sistema y carece de permisos para dar de baja entidades.

## 📝 Validaciones

El sistema incluye una serie de validaciones automáticas:
*   Todos los textboxes de caracteres aseguran que sólo se ingrese información válida (números en el DNI / Teléfono).
*   Comprobación de registros duplicados en base de datos al momento de ingresar DNIs.
*   Protección contra modificaciones accidentales al tornar de sólo-lectura campos críticos (como el DNI) al momento de editar clientes o usuarios existentes.

## 👨‍💻 Contribuir

1. Realice un _fork_ del proyecto.
2. Cree una rama para su respectiva funcionalidad (`git checkout -b feature/NuevaFuncionalidad`).
3. Confirme sus cambios (`git commit -m 'Agregar NuevaFuncionalidad'`).
4. Realice un _push_ a la rama (`git push origin feature/NuevaFuncionalidad`).
5. Abra un _Pull Request_ detallando los cambios.
