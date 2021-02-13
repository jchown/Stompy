# Stompy

Kills rogue Kotlin/Java compiler daemons

Due to <a href="https://youtrack.jetbrains.com/issue/KT-36253">this bug</a>, our workflow in IntelliJ is almost unusable,
as one of the Kotlin or Java compiler daemons launched by the IDE or Gradle fails to close a handle.

This small program therefore kills <i>all orphaned</i> Java processes.

When running it looks like this:

```
S S:\Programs\Stompy> .\Stompy.exe
Looking for rogue Kotlin compile processes...
05/02/2021 10:02:31: Java orphan processes found
05/02/2021 10:02:31: Killing PID 50032
05/02/2021 10:03:38: Java orphan processes found
05/02/2021 10:03:38: Killing PID 34744
05/02/2021 10:05:35: Java orphan processes found
05/02/2021 10:05:35: Killing PID 50192
05/02/2021 10:05:35: Killing PID 50164
05/02/2021 10:13:22: Java orphan processes found
05/02/2021 10:13:22: Killing PID 36292
```

This has made working in IntelliJ a little less excruciating.

### Credits

Minimal code by Jason Chown, the only clever bit was copied from Stack Overflow.
<p>
Icon by <a href="https://www.freepik.com" title="Freepik">Freepik</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a>  
