# Prototipo - Grupo 4
## Interfaces Inteligentes - Curso 2023 - 2024

> Laura Ramallo Pérez
> 
> Adrián Sanz Fernández
> 
> Helena García Díaz

# Introducción

En el presente documento se recoge el trabajo realizado a la hora de desarrollar el prototipo final de la asignatura.

Se trata de un juego de pistas de temática tenebrosa, en el que se debe ir siguiendo indicaciones y realizando tareas, hasta llegar al final del mismo. Se trata de una idea original, en la que hemos intentado integrar las diferentes prácticas que se han realizado durante el curso.

# Modo de uso

El presente juego debe jugarse con mando o teclado, ya que se debe poder controlar el movimiento del jugador y las teclas de acción del juego.

> **Con mando**
> 
> *Teclas de movimiento*: Joystick del mando.
> 
> *Teclas de acción*: Botones del mando.
>
> 
> **Con teclado**
> 
> *Teclas de movimiento*: Flechas de dirección.
> 
> *Teclas de acción*: Letras del teclado.

# Hitos de programación logrados

1. Uso de delegados y eventos a lo largo de todo el juego.
2. Uso de físicas en el juego.
3. Movimiento del jugador.
4. Uso del Google Cardboard para inmersión e interacción con los objetos del entorno.
5. Uso de elementos de audio, así como reconocimiento del habla.
6. Uso de sensores del móvil.

# Funcionamiento de la aplicación

Cuando iniciamos el juego, nos encontramos dentro una cabaña y nos llama la atención el mensaje de la pizarra, a la vez que comienza a sonar una música tenebrosa. En la pizarra se nos indica que debemos buscar un libro, y luego nos dicen que debemos usar nuestra magia, pulsando el botón B del mando, para mover una caja. Después de ello, debemos buscar una llave para abrir la puerta, y nos vamos a la siguiente habitación.

> *Nota:* Durante el vídeo hay cortes de edición para que dure menos tiempo y por tanto el archivo pese menos.

`videos/Primera parte.mp4`



https://github.com/InterfacesInteligentes2324/Prototipo/assets/72279658/1f4226e3-a566-4f49-9bd3-42bf43564a6e



https://github.com/InterfacesInteligentes2324/Prototipo/assets/72279658/f1866b91-debe-4324-aeea-7784d2a0e27a



Luego, nos vemos dentro de un hangar, donde una voz nos dice que debemos recoger una maletas. En esta emulación en PC, como no tenemos sensores, no podemos utilizarlos, pero en móvil, las estatuas se mueven dependiendo de a dónde miremos, utilizando el giroscopio del móvil. Cuando recogemos las maletas, nos dicen que debemos buscar una llave, y nos vamos a la siguiente habitación.

`videos/Segunda parte.mp4`


https://github.com/InterfacesInteligentes2324/Prototipo/assets/72279658/c7c58462-4ab8-4dc0-ab7c-a832c5fe27fb



https://github.com/InterfacesInteligentes2324/Prototipo/assets/72279658/bdeba9bf-86cb-41b4-8852-faae815db091



https://github.com/InterfacesInteligentes2324/Prototipo/assets/72279658/01d3182d-7b72-4911-93de-d2be26d85acb




En la tercera habitación, aparecemos en una casa y

# Acta de trabajo

Para realizar el presente trabajo tuvimos que llegar a una serie de acuerdos. Nos hemos reunido todos en diferentes ocasiones para evaluar el estado del proyecto y los siguientes hitos a cumplir. Así como unir el trabajo que se realizó de manera independiente, comentar los bugs encontrados en el juego, posibles ideas y solución de errores. Del mismo modo, todos hemos colaborado en la elaboración del informe y entrega final de este proyecto.

A parte de eso, nos hemos tenido que coordinar para trabajar de manera asíncrona con los archivos del juego. En cuanto a realización de tareas específicas, podemos identificarlas de esta manera.

#### Adrián

1. Preparación del proyecto inicial, para ello, configuré la escena para que funcionase correctamente con carboard e incluí una cabaña y los elementos dentro de esta.
2. Creción de los eventos principales del juego para los controladores, por ejemplo AparecerLlave(), que se encarga de activar el objeto llave cuando se han recogido todas las maletas o la estructura base de los controladores, asi como algunos más concretos como controlador_caja que se encarga también del movimiento de la caja en el evento
3. A lo anterior, tambien se une algunas partes claves para el juego, como por ejemplo la implementación de la llave y la base para la lógica del teletransporte
4. Por otro lado, implementé todo lo relacionado con sensores, es decir, las estatuas que giran en el hangar siguiendo los conocimientos de clase.
5. 
6. Me encargué de corregir los errores que iban surgiendo durante el desarrolló del proyecto asi como de ser un poco el que ha dirigido el proyecto
   

1. Preparación de la UI de texto para colocar las pistas del usuario.
2. asd
   
#### Helena

1. A partir del proyecto inicial preparado por Adrián, donde ya se incluía la caseta, añadí música cuando se miraba a la pizarra (era una de las pistas para el jugador), lo que en una posterior implementación se cambió a música ambiente durante todo el juego.
2. Movimiento del jugador, con teclado y mando. Para ello utilicé la configuración por defecto que trae Unity, lo que permite detectar los ejes horizontal y vertical a partir de las teclas de dirección del teclado, y del joystick del mando. Luego, realizando transformaciones como en los ejercicios de clase, se implementa una rotación vertical del jugador usando el eje horizontal, y el movimiento hacia atrás y adelante con el eje vertical más la rotación. Además, añadí las teclas del mando en las ya definidas para la interacción con el entorno.
3. Modifiqué también al jugador para que tuviera físicas y no pudiera traspasar las paredes. Esto lo logré cologando un rigidbody y un box collider en el objeto que teníamos para el jugador. En el box collider, modifiqué la mesh del mismo para que estuviera en los pies del jugador. de este modo, es suficiente para que no pueda salir de los recintos, y pueda colisionar con su entorno. También comprobé que en el resto de escenarios, el jugador permanecía dentro de las habitaciones.
4. Adición del hangar. Adrián y yo estuvimos buscando diferentes modelos en la AssetStore y encontramos este que era un espacio amplio que nos permitía hacer las ideas que teníamos, además de que pesaba poco. Al principio el jugador podía traspasar las paredes, con lo que creé un objeto vacío de paredes, y fui añadiendo objetos con rigidbodies y boxcolliders, y los modifiqué para que coincidienran con las paredes pero no se chocaran entre sí.
5. Busqué un objeto de maleta en la AssetStore y le añadí un rigidbody y le ajusté un boxcollider, para que el jugador pudiera chocar con ella. Además, le añadí un script utilizando delegados y eventos, para que cuando detectara una colisión con el jugador, lo notificara como que se había recogido una maleta, y desactivara el objeto. De esta manera, en el controlador del texto, se recibe este mensaje y se va aumentando el contador de maletas recogidas. Además, a una de las maletas le puse que se le aplicara una fuerza vertical hacia arriba que la moviera, como si estuviera poseída, para que fuera un reto mayor para el jugador atraparla.
6. También he realizado la mayor parte de la redacción del informe, a excepción de la parte de esta acta donde se recoge el trabajo de cada uno.
