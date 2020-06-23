Checkout to `JsonbArrayBugMinRepro` directory and type in command line `dotnet ef database update` to apply database schema.

Application will print exception to stdout.

```
Microsoft.EntityFrameworkCore.DbUpdateException: An error occurred while updating the entries. See the inner exception for details.
 ---> Npgsql.PostgresException (0x80004005): 42804: column "JsonbArray" is of type jsonb[] but expression is of type text[]
   at Npgsql.NpgsqlConnector.<>c__DisplayClass160_0.<<DoReadMessage>g__ReadMessageLong|0>d.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at Npgsql.NpgsqlConnector.<>c__DisplayClass160_0.<<DoReadMessage>g__ReadMessageLong|0>d.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at Npgsql.NpgsqlDataReader.NextResult(Boolean async, Boolean isConsuming)
   at Npgsql.NpgsqlCommand.ExecuteReaderAsync(CommandBehavior behavior, Boolean async, CancellationToken cancellationToken)
   at Npgsql.NpgsqlCommand.ExecuteDbDataReaderAsync(CommandBehavior behavior, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReaderAsync(RelationalCommandParameterObject parameterObject, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReaderAsync(RelationalCommandParameterObject parameterObject, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReaderAsync(RelationalCommandParameterObject parameterObject, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.ExecuteAsync(IRelationalConnection connection, CancellationToken cancellationToken)
  Exception data:
    Severity: ERROR
    SqlState: 42804
    MessageText: column "JsonbArray" is of type jsonb[] but expression is of type text[]
    Hint: You will need to rewrite or cast the expression.
    Position: 45
    File: parse_target.c
    Line: 591
    Routine: transformAssignedExpr
   --- End of inner exception stack trace ---
   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.ExecuteAsync(IRelationalConnection connection, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.Update.Internal.BatchExecutor.ExecuteAsync(IEnumerable`1 commandBatches, IRelationalConnection connection, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.Update.Internal.BatchExecutor.ExecuteAsync(IEnumerable`1 commandBatches, IRelationalConnection connection, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChangesAsync(IList`1 entriesToSave, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChangesAsync(DbContext _, Boolean acceptAllChangesOnSuccess, CancellationToken cancellationToken)
   at Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.NpgsqlExecutionStrategy.ExecuteAsync[TState,TResult](TState state, Func`4 operation, Func`4 verifySucceeded, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.DbContext.SaveChangesAsync(Boolean acceptAllChangesOnSuccess, CancellationToken cancellationToken)
   at JsonbArrayBugMinRepro.Program.Main() in C:\Users\lszafirski\source\repos\JsonbArrayBugMinRepro\JsonbArrayBugMinRepro\Program.cs:line 23
```