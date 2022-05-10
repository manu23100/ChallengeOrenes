A continuación comentaremos cómo se han desarrollado los dos niveles requeridos.

**Nivel 1**

Se han desarrollado diferentes funcionalidades para la gestión de las localizaciones de los vehículos. 

 - Insertar una nueva localización (/Locations) : Se añadirá una nueva localización al vehículo con el Id proporcionado en el objeto que representa a la localización. De ésta manera podemos actualizar la localización de un determinado vehículo.
 - Obtener la localización actual de un vehículo (/Vehicles/currentLocation/id): Devolverá la localización actual del vehículo. Si el vehículo no existe o éste no tiene una localización asociada, devolverá una error.
 - Obtener el historial de localizaciones de un vehículo (/Vehicles/locationsHistory/id): Devuelve el historial de todas las localizaciones añadidas a un vehículo ( si éste no existe, devolverá un error).
 
 Además, se incluyen las funcionalidades de añadir/borrar pedidos a un vehículo.
 
 - Añadir un nuevo pedido (/Orders): Añadirá un pedido a la lista de pedidos de un vehículo y un usuario. Si el vehículo o el usuario no existen, lanza un error.
 - Eliminar un pedido existente(/Orders/id): Si el pedido con el id especificado existe, lo elimina. En caso contrario, se lanzará un error. Elimina el pedido tanto de la lista de pedidos del vehículo como de los pedidos del usuario.

**Nivel 2**

Para notificar al usuario de una nueva localización, se ha hecho uso del protocolo MQTT.

Se ha desarrollado un suscriber que estára a la espera de recibir la notificación de una nueva localización.

El publisher será el encargado de enviar la localización al suscriber. Una vez la envíe se desconectará.

Para realizar la conexión del suscriber utilizaremos la ruta /Mqtt/connect.

Para hacer que el publisher se conecte y envíe una nueva localización, utilizaremos la ruta /Mqtt/newLocation.

**Diseño de la solución**
El diseño consta de una arquitectura multicapa, haciendo uso de la capa REST API (haciendo uso de los controladores para poder interactuar con ella), la capa de repositorios y la capa de servicios.

Para el mapeo de las entidades se ha utilizado Entity Framework, siguiendo la metodología Code First, de forma que la creación de la BD se haga a partir del código implementado.

Para el desarrollo se ha utilizado Visual Studio 2022,


**Lanzamiento de la aplicación**
