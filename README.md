# AppWeb

Este proyecto forma parte de la asignatura "Herramientas Avanzadas de Desarrollo de Software".

## Configuración

Antes de poder utilizar la aplicación se require cambiar cierta configuración.

### Base de Datos

Debes introducir la "connection string" de la base de datos MsSQL en el archivo ubicado `sqlServerDb/Connection.cs`. Se muestra a continuación el apartado del código correspondiente, reemplazar `CONNECTION_STRING`.

```cs
public Connection()
{
    string connectionString = "CONNECTION_STRING";
    connected = false;
    connection = new SqlConnection(connectionString);
}
```

### Servidor SMTP de correos salientes

Para poder enviar correos durante el registro del usuario. La configuración de este se encuentra en `web/Web.config`.

* `SEND_FROM`: dirección de correo saliente, ej. `noreply@domain.tld`
* `SMTP_SERVER`: dirección smtp del servidor, ej. `smtp.domain.tld`
* `MAIL_USER`: nombre de usuario para la autenticación.
* `MAIL_PASS`: contraseña para autenticación del usuario.

```xml
<mailSettings>
  <smtp from="SEND_FROM">
    <network
      host="SMTP_SERVER"
      port="587"
      userName="MAIL_USER"
      password="MAIL_USER_PASS"
      enableSsl="true" />
  </smtp>
</mailSettings>
```
