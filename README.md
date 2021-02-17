# AppWeb

Este proyecto forma parte de la asignatura "Herramientas Avanzadas de Desarrollo de Software".

## Configuración

Antes de poder utilizar la aplicación se require cambiar cierta configuración. Primero de todo tienes que hacer una copia del archivo `web/Web.config.example` y llamarla `Web.config`, una vez hecha la copia tienes que hacer los siguientes cambios.

### Base de Datos

Debes remplazar `CONNECTION_STRING` por la "connection string" de la base de datos SQLserver.

```xml
<connectionStrings>
  <add
    name="sqlserver"
    connectionString="CONNECTION_STRING"/>
</connectionStrings>
```

### Servidor SMTP de correos salientes

Esta configuración consiste en varios parámetros, a continuación se explican cada uno de los valores que deben tomar cada uno de ellos.

* `FROM_ADDRESS`: dirección de correo saliente, ej. `noreply@domain.tld`
* `SMTP_HOST`: dirección smtp del servidor, ej. `smtp.domain.tld`
* `AUTH_USER`: nombre de usuario para la autenticación.
* `AUTH_PASS`: contraseña para autenticación del usuario.

```xml
<mailSettings>
  <smtp from="FROM_ADDRESS">
    <network
      host="SMTP_HOST"
      port="587"
      userName="AUTH_USER"
      password="AUTH_PASS"
      enableSsl="true"/>
  </smtp>
</mailSettings>
```
