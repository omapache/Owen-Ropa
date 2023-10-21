# Caso Safe Clothing

Este proyecto proporciona una API que permite llevar el control, registro y seguimiento de la producción de prendas de seguridad industrial.

## Características 🌟

- Registro de usuarios.
- Autenticación con usuario y contraseña.
- Generación y utilización del token.
- CRUD completo para cada entidad.
- Vista de las consultas requeridas.

## Uso 🕹

Una vez que el proyecto esté en marcha, puedes acceder a los diferentes endpoints disponibles:

En el archivo CSV se encuentra registrado el administrador con:  
 **usuario**: `Admin`  
 **Contraseña**: `123`   
Necesitaremos de este usuario para obtener el token que se utilizará para el registro de usuarios, ya que solo el administrador podra hacer todo con respecto al CRUD de los usuarios.

## 1. Generación del token 🔑:

**Endpoint**: `http://localhost:5272/api/usuario/token`

**Método**: `POST`

**Payload**:

`{
    "Nombre": "Admin",
    "Contraseña": "123"
}`

Al obtener el token del administrador, se podrá realizar el registro de usuarios.

## 2. Registro de Usuarios 📝:

**Endpoint**: `http://localhost:5272/api/usuario/register`

**Método**: `POST`

**Payload**:

json
`{
    "Usuario": "<nombre_de_usuario>",
    "Contraseña": "<contraseña>",
    "CorreoElectronico": "<correo_electronico>"
}`

Este endpoint permite a los usuarios registrarse en el sistema.

Una vez registrado el usuario tendrá que ingresar para recibir un token, este será ingresado al siguiente Endpoint que es el de Refresh Token.

## 3. Refresh Token 🔄:

**Endpoint**: `http://localhost:5272/api/usuario/refresh-token`

**Método**: `POST`

**Payload**:

`{
    "Nombre": "<nombre_de_usuario>",
    "Contraseña": "<contraseña>"
}`

Se dejan los mismos datos en el Body y luego se ingresa al "Auth", "Bearer", allí se ingresa el token obtenido en el anterior Endpoint.

**Otros Endpoints**

Obtener Todos los Usuarios: GET `http://localhost:5272/api/usuario`

Obtener Usuario por ID: GET `http://localhost:5272/api/usuario/{id}`

Actualizar Usuario: PUT `http://localhost:5272/api/usuario/{id}`

Eliminar Usuario: DELETE `http://localhost:5272/api/usuario/{id}`


## Desarrollo de los Endpoints requeridos⌨️

Cada Endpoint tiene su versión 1.0 y 1.1, al igual que están con y sin paginación.

Para consultar la versión 1.0 de todos se ingresa únicamente el Endpoint.

## 1. Listar los proveedores que sean persona natural.

    **Endpoint**: `http://localhost:5272/api/proveedor/consulta1`
    
    **Método**: `GET`

## 2.Listar las prendas de una orden de producción cuyo estado sea en producción. El usuario debe ingresar el número de orden de producción.

    **Endpoint**: `http://localhost:5272/api/prenda/consulta2/{NroOrdenProduccion}`
    
    **Método**: `GET`

## 3.Listar las prendas agrupadas por el tipo de protección.

    **Endpoint**: `http://localhost:5272/api/prenda/consulta3`
    
    **Método**: `GET`


## 4. Listar las ordenes de producción que pertenecen a un cliente especifico. El usuario debe ingresar el IdCliente y debe obtener la siguiente información:

1. IdCliente, Nombre, Municipio donde se encuentra ubicado.
2. Nro de orden de producción, fecha y el estado de la orden de producción (Se debe mostrar la descripción del estado, código del estado, valor total de la orden de producción.
3. Detalle de orden: Nombre de la prenda, Código de la prenda, Cantidad, Valor total en pesos y en dólares.

    **Endpoint**: `http://localhost:5272/api/cliente/consulta4/{idCliente}`
    
    **Método**: `GET`

## 5.Listar los insumos de una prenda y calcular cuanto cuesta producir una prenda especifica. El costo de la prenda dependerá de la cantidad de insumos que sean necesarios para la producción de la misma. El usuario debe ingresar en Id de la prenda.

    **Endpoint**: `http://localhost:5272/api/insumoprenda/consulta5/{IdPrenda}`
    
    **Método**: `GET`


## 6. Listar los insumos que son vendidos por un determinado proveedor. El usuario debe ingresar el Nit de proveedor.

    **Endpoint**: `http://localhost:5272/api/proveedor/consulta6`
    
    **Método**: `GET`

## 7. Listar las ventas realizadas por un empleado especifico. El usuario debe ingresar el Id del empleado y mostrar la siguiente información.

1. Id Empleado
2. Nombre del empleado
3. Fecturas : Nro Factura, fecha y total de la factura.

        **Endpoint**: `http://localhost:5272/api/venta/consulta7/{IdEmpleado}`
        
        **Método**: `GET`     

Para consultar la versión 1.1 se deben seguir los siguientes pasos:  

En el Thunder Client se va al apartado de "Headers" y se ingresa lo siguiente:

![image](https://github.com/SilviaJaimes/Proyecto-Veterinaria/assets/132016483/8044ee3d-76d9-4437-9f08-da8e5d7cff9a)

Para realizar la paginación se va al apartado de "Query" y se ingresa lo siguiente:

![image](https://github.com/SilviaJaimes/Proyecto-Veterinaria/assets/132016483/22683e46-037e-4f30-96b8-161df8622b40)


## Desarrollo ⌨️
Este proyecto utiliza varias tecnologías y patrones, incluidos:  

Patrón Repository y Unit of Work para la gestión de datos.  

AutoMapper para el mapeo entre entidades y DTOs.  

## Agradecimientos 🎁

A todas las librerías y herramientas utilizadas en este proyecto.

A ti, por considerar el uso de este sistema.

Echo por Owen 🦝
