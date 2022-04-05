# Api_Asteroids
By Eduardo Celis

1. DESCRIPCIÓN DE LA PRUEBA

Exponer un endpoint que reciba un planeta como parámetro y que devuelva un listado en
formato json con el top 3 de asteroides más grandes con potencial riesgo de impacto en dicho
planeta en los próximos 7 días. En caso de que no haya 3 o más planetas bajo estas
condiciones, devolver los que sea que apliquen. 

Ejemplo de endpoint: /asteroids?planet=earth 

El parámetro planet es obligatorio. Si no se especifica, se debe devolver un error controlado
indicando este hecho. 

Los datos se recogen de la siguiente API, deben transformarse y construir la respuesta con la
estructura planteada más abajo. 

https://api.nasa.gov/neo/rest/v1/feed?start_date=2020-09-09&end_date=2020-0916&api_key=DEMO_KEY

Campos clave del servicio de la NASA para la obtención de resultados: 

• "is_potentially_hazardous_asteroid" = true
• "estimated_diameter:kilometers: estimated_diameter_min" y 
"estimated_diameter:kilometers: estimated_diameter_max": Para calcular el tamaño medio.
• "close_approach_date:orbiting_body": Planeta recibido por query param 
Campos de respuesta del endpoint /asteroids, devolver json con: 
• nombre: Obtenido de "name",
• diametro: Tamaño medio calculado
• velocidad: "close_approach_data:relative_velocity:kilometers_per_hour"
• fecha: "close_approach_data:close_approach_date" 
• planeta: "close_approach_date:orbiting_body" 

2. RESTRICCIONES 

• Tecnológicas, nuestro planteamiento es que utilices las siguientes herramientas, pero no
estamos limitados a ellas.
- .Net CORE/NET5, Asp.net WebApi
- Test xUnit/NUnit/MsTest (a elegir) y Moq 
• Publicar en git o en cualquier repositorio en el que podamos acceder.
- ¡Nos gusta ver la evolución del código tras cada subida!  
• Implementar tests unitarios.
• Principios SOLID. Foco en estructura de código ordenado y buenas prácticas de
programación. 

NOTA sobre el parámetro API_KEY 

Los datos se obtienen de APIs abiertas propiedad de la NASA. El parámetro
API_KEY=DEMO_KEY tiene ciertas limitaciones que pueden ser consultadas en la siguiente web 

https://api.nasa.gov/ 

Alternativamente, puedes utilizar la siguiente api_key que ponemos a tu disposición para el
desarrollo de la prueba. 

API_KEY= zdUP8ElJv1cehFM0rsZVSQN7uBVxlDnu4diHlLSb
