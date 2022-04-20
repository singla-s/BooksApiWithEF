Run Migration Commands:

## Model First Approach:

Add-Migration Initial
Update-Database

## Database First Approach

scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LoggingDB;Integrated Security=True;Pooling=False" Microsoft.EntityFrameworkCore.SqlServer -outputdir Models
