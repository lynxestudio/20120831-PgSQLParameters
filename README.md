# Utilizando parameterized commands (comandos con parámetros) de ADO.NET en PostgreSQL con C#

Aunque este tutorial se centra en PostgreSQL, utilizo la clase genérica
DbCommand, ya que estos conceptos son aplicables a otros manejadores de bases de datos como Oracle o SQL Server, únicamente reemplazando las clases DbCommand y DbParameter por las clases específicas de ADO .NET para estas bases de datos.


La clase DbCommand de ADO .NET nos proporciona la capacidad de ejecutar comandos parametrizados, lo que nos permite pasar información en tiempo de ejecución a los store procedures o comandos SQL que nuestra aplicación .NET envié hacia la base de datos.
Estos parámetros se clasifican por su valor dentro de la enumeración ParameterDirection:


Input: Son el tipo predeterminado, envía los valores hacia la base de datos, es posible tener múltiples parámetros de entrada.

Output: Similar a los parámetros Input, solo que regresan los valores de retorno una vez que el comando es ejecutado, es posible tener múltiples parámetros de salida.

InputOutput: El parámetro es capaz de enviar y recibir un valor después de que el comando es ejecutado.

ReturnValue: El parámetro representa el valor de retorno de la función.


El uso de comandos parametrizados nos ofrece los siguientes beneficios:


Nos permite definir el tipo de dato del parámetro.

Evita la concatenación de sentencias SQL en el código, con lo que disminuye el riesgo de un ataque SQL Injection.

Obtenemos un mejor rendimiento, las consultas pre-compiladas tienen un mejor desempeño al ejecutarse ya que el plan de ejecución es reutilizado para la misma consulta en vez construirlo repetidamente en cada ejecución como ocurre con las consultas SQL literales.

Los parámetros son revisados y validados para comprobar que no exista código malicioso, una de esas validaciones es la longitud, por ejemplo si el parámetro especifica una longitud de 50 caracteres, entonces solo 50 caracteres serán aceptados.


DbCommand tiene la propiedad Parameters que representa la colección de parámetros que están asociados al comando SQL. Estos parámetros son representados por el objeto DbParameter el cual tiene las siguientes propiedades:

DbType: Representa el tipo de dato de la fuente de datos como un tipo CLR.
Direction: Indica si el parámetro es de entrada, de salida o bidireccional.
IsNullable: Indica si el parámetro acepta valores nulos.
ParameterName: Representa el nombre del parámetro.
Size: Representa la longitud del parámetro.
Value: Obtiene u establece el valor del parámetro.

Como ejemplo un programa C# que muestra el uso de los comandos parametrizados llamando a una función de PL/pgSQL en PostgreSQL que realiza una concatenación de un número aleatorio, el año actual y el parámetro de entrada para crear un número distinto cada vez que se ejecute.
El código PL/pgsql de la función es el siguiente:



El resultado de la ejecución de la función es:



A continuación un ejemplo en C# en donde se muestra el uso de los parámetros ejecutando la función anterior con su parámetro de entrada (input) y recibiendo el valor de retorno.





Este ejemplo en MonoDevelop puede construirse como una aplicación de consola, agregando las refrencias al ensamblado Npgsql, como se muestra en la siguiente imagen:




La salida de la ejecucción de este programa es:



Si se ejecuta desde MonoDevelop la salida es:

