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

> Link a la apk
>
> https://drive.google.com/file/d/1jWRZQOe_JZ1toQjNBu-qWO49CHJd3_ds/view?usp=sharing
>
> ![](./QR/apk.png)

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

## 1. Uso de Delegados y Eventos
Implementamos delegados y eventos para manejar acciones específicas en el juego. Por ejemplo, en nuestro controlador de llaves (`controlador_llave.cs`), utilizamos estos mecanismos para notificar cuando una llave es recogida. Definimos delegados como `public delegate void KeyCollectedAction()` y eventos asociados, que luego se disparan en momentos clave del juego, permitiendo una comunicación efectiva y modular entre diferentes scripts.

## 2. Uso de Físicas
En nuestro manejo de físicas, utilizamos componentes `Rigidbody` para agregar realismo. Un ejemplo claro es en nuestro `controlador_caja.cs`, donde aplicamos físicas para simular la interacción con una caja. Implementamos colisiones y fuerzas para crear una experiencia de juego más inmersiva, empleando métodos como `OnCollisionEnter` y `AddForce`, tal y como se puede ver  en `SuitcaseController.cs` (donde además se puede ver también el uso de delegados y eventos).

## 3. Movimiento del Jugador
Desarrollamos un sistema de control del jugador utilizando `Input.GetAxis` para capturar entradas del teclado o joystick en los ejes vertical y horizontal. Aplicamos estas entradas para mover el objeto del jugador usando transformaciones y ajustes en su `Rigidbody`, logrando un movimiento fluido y receptivo.

## 4. Uso del Google Cardboard
Integramos Google Cardboard para transformar el juego en una experiencia de realidad virtual. Configuramos la cámara de Unity para adaptarla a las necesidades de VR y desarrollamos un sistema de interacción basado en la mirada y el uso de controladores VR, permitiendo a los usuarios interactuar de manera intuitiva con el entorno virtual.

## 5. Uso de Elementos de Audio y Reconocimiento del Habla
Implementamos un sistema de audio utilizando `AudioSource` y `AudioClip` para reproducir sonidos ambientales y efectos. Además, planeamos integrar un SDK de reconocimiento de voz, lo que permitiría a los jugadores interactuar con el juego mediante comandos de voz, aumentando la inmersión y la accesibilidad.

## 6. Uso de Sensores del Móvil
Aprovechamos los sensores del móvil, como el acelerómetro y el giroscopio, accesibles a través de `Input.acceleration` y `Input.gyro`. Estos datos se utilizaron para controlar aspectos del juego como la orientación de la cámara y el movimiento del personaje, ofreciendo una experiencia de juego más integrada y reactiva a los movimientos físicos del jugador.

# Funcionamiento de la aplicación

Cuando iniciamos el juego, nos encontramos dentro una cabaña y nos llama la atención el mensaje de la pizarra, a la vez que comienza a sonar una música tenebrosa. En la pizarra se nos indica que debemos buscar un libro, y luego nos dicen que debemos usar nuestra magia, pulsando el botón B del mando, para mover una caja. Después de ello, debemos buscar una llave para abrir la puerta, y nos vamos a la siguiente habitación.

> *Nota:* Durante el vídeo hay cortes de edición para que dure menos tiempo y por tanto el archivo pese menos.

`videos/Primera parte.mp4`



https://github.com/InterfacesInteligentes2324/Prototipo/assets/72279658/1f4226e3-a566-4f49-9bd3-42bf43564a6e



https://github.com/InterfacesInteligentes2324/Prototipo/assets/72279658/f1866b91-debe-4324-aeea-7784d2a0e27a



Luego, nos vemos dentro de un hangar, donde una voz nos dice que debemos recoger una maletas. En esta emulación en PC, como no tenemos sensores, no podemos utilizarlos, pero en móvil (ver vídeo), las estatuas se mueven dependiendo de a dónde miremos, utilizando el giroscopio del móvil. Cuando recogemos las maletas, nos dicen que debemos buscar una llave, y nos vamos a la siguiente habitación.

`videos/Segunda parte.mp4`


https://github.com/InterfacesInteligentes2324/Prototipo/assets/72279658/c7c58462-4ab8-4dc0-ab7c-a832c5fe27fb



https://github.com/InterfacesInteligentes2324/Prototipo/assets/72279658/bdeba9bf-86cb-41b4-8852-faae815db091



https://github.com/InterfacesInteligentes2324/Prototipo/assets/72279658/01d3182d-7b72-4911-93de-d2be26d85acb



En la tercera habitación, ambientada en una casa misteriosa, el jugador debe hallar una nota oculta. A primera vista, la nota parece estar en blanco, pero revela su contenido bajo una luz especial. Para esto, el jugador debe encontrar una linterna específica. Una vez iluminada la nota, se despliega un acertijo.

Aquí empleamos un sistema de reconocimiento de habla: el jugador se acerca al cofre, lo observa y verbaliza la respuesta del acertijo. Si acierta, el cofre se abre automáticamente. Paralelamente, un sistema de delegados y eventos controla el progreso del juego, asegurando que las acciones se realicen en el orden correcto y aumentando un contador de objetivos para mantener el flujo narrativo y lógico del juego.


https://github.com/InterfacesInteligentes2324/Prototipo/assets/72279658/bcc3630f-e05d-4937-a370-536ff523d58f


https://github.com/InterfacesInteligentes2324/Prototipo/assets/72279658/7c3a7b87-eeca-469a-b289-8b2745642b9b


https://github.com/InterfacesInteligentes2324/Prototipo/assets/72279658/51ef3a13-e7e4-417a-b698-599a3cb1b4ab



Aquí se puede ver una simulación en móvil. La calidad está algo reducida, ya que fue grabado directamente en la pantalla del mismo, pero en ella se puede ver que el juego funciona de manera fluida y según como se espera. Llegamos a ver hasta la llegada al hangar, ya que el movimiento del jugador se podrá ver en clase, utilizando el mando de la profesora. Pero hemos hecho pruebas en Unity con un mando de Xbox y funcionaba perfectamente.


https://github.com/InterfacesInteligentes2324/Prototipo/assets/72279658/fa8ece29-8f82-4866-9f92-0cf873669b97



# Acta de trabajo

Para realizar el presente trabajo tuvimos que llegar a una serie de acuerdos. Nos hemos reunido todos en diferentes ocasiones para evaluar el estado del proyecto y los siguientes hitos a cumplir. Así como unir el trabajo que se realizó de manera independiente, comentar los bugs encontrados en el juego, posibles ideas y solución de errores. Del mismo modo, todos hemos colaborado en la elaboración del informe y entrega final de este proyecto.

A parte de eso, nos hemos tenido que coordinar para trabajar de manera asíncrona con los archivos del juego. En cuanto a realización de tareas específicas, podemos identificarlas de esta manera.

#### Adrián

1. Preparación del proyecto inicial, para ello, configuré la escena para que funcionase correctamente con carboard e incluí una cabaña y los elementos dentro de esta.
2. Creción de los eventos principales del juego para los controladores, por ejemplo `AparecerLlave()`, que se encarga de activar el objeto llave cuando se han recogido todas las maletas o la estructura base de los controladores, asi como algunos más concretos como `controlador_caj`a que se encarga también del movimiento de la caja en el evento de la primera sala.
3. A lo anterior, tambien se une algunas partes claves para el juego, como por ejemplo la implementación de la llave y la base para la lógica del teletransporte.
4. Por otro lado, implementé todo lo relacionado con sensores, es decir, las estatuas que giran en el hangar siguiendo los conocimientos de clase.
5. Me encargué de dirigir la gran parte del proyecto, coordinando que no quedara ninguna parte pendiente sin hacer.
   

#### Laura

1. Inicié el proyecto configurando la interfaz de usuario (UI) para mostrar texto, lo cual incluye la implementación de un sistema de pistas para los usuarios, así como un contador que lleva registro del progreso dentro del juego, y el script asociado.
2. Desarrollé la última sala del juego, para lo cual importé diversos elementos como el paquete de la casa, el tesoro y el clipboard, asegurándome de que todos los componentes se integraran correctamente en el entorno virtual. Además, me encargué de escribir los scripts de estos elementos, incluyendo la linterna.
3. Implementé un sistema de reconocimiento por voz, diseñado específicamente para interactuar con el tesoro dentro del juego, permitiendo a los usuarios abrirlo mediante comandos de voz.
4. Me encargué de la creación de la narrativa y los diálogos del juego, elaborando una historia envolvente que enriquece la experiencia del jugador.
5. Finalicé el proyecto configurando y adaptando todos los elementos necesarios para exportarlo como una aplicación (apk), asegurándome de que el juego fuera compatible y funcionara de manera óptima en dispositivos móviles.
   
#### Helena

1. A partir del proyecto inicial preparado por Adrián, donde ya se incluía la caseta, añadí música cuando se miraba a la pizarra (una de las pistas para el jugador), y paraba cuando se dejaba de mirarla, lo que en una posterior implementación se cambió a música ambiente durante todo el juego.
2. Movimiento del jugador, con teclado y mando. Para ello utilicé la configuración por defecto que trae Unity, lo que permite detectar los ejes horizontal y vertical a partir de las teclas de dirección del teclado, y del joystick del mando. Luego, realizando transformaciones como en los ejercicios de clase, se implementa una rotación vertical del jugador usando el eje horizontal, y el movimiento hacia atrás y adelante con el eje vertical más la rotación. Además, añadí las teclas del mando en las ya definidas para la interacción con el entorno. Esto también permitió que en el móvil, se pudiera interactuar con los elementos haciendo tap en la *pantalla*.
3. Modifiqué también al jugador para que tuviera físicas y no pudiera traspasar las paredes. Esto lo logré cologando un rigidbody y un box collider en el objeto que teníamos para el jugador. En el box collider, modifiqué la mesh del mismo para que estuviera en los pies del jugador. De este modo, es suficiente para que no pueda salir de los recintos, y pueda colisionar con su entorno. También comprobé que en el resto de escenarios, el jugador permanecía dentro de las habitaciones.
4. Adición del hangar. Adrián y yo estuvimos buscando diferentes modelos en la AssetStore y encontramos este que era un espacio amplio que nos permitía hacer las ideas que teníamos, además de que pesaba poco. Al principio el jugador podía traspasar las paredes, con lo que creé un objeto vacío de paredes, y fui añadiendo objetos con rigidbodies y boxcolliders, y los modifiqué para que coincidienran con las paredes pero no se chocaran entre sí.
5. Busqué un objeto de maleta en la AssetStore y le añadí un rigidbody y le ajusté la mesh de un boxcollider, para que el jugador pudiera chocar con ella. Además, le añadí un script utilizando delegados y eventos, para que cuando detectara una colisión con el jugador, lo notificara como que se había recogido una maleta, y desactivara el objeto. De esta manera, en el controlador del texto, se recibe este mensaje y se va aumentando el contador de maletas recogidas. de esta manera, luego sólo tuve que copiar este elemento y usarlo como prefab para tener la cantidad de maletas que quisiera.
6. También he realizado la mayor parte de la redacción del informe, a excepción de la parte de esta acta donde se recoge el trabajo de cada uno.  También realicé la grabación de las escenas del juego, tanto en pc como en móvil (era la única que tenía dispositivo Android) y su posterior edición para que pudieran ser subidas al proyecto.


> Link al proyecto completo de Unity
>
> https://drive.google.com/file/d/1sf7SF3ONx9yfi-jUgp6RQH7IIeIrgEtH/view
>
> ![](./QR/proyecto.png)
