﻿namespace ScoreHub_Infrastructure;

public class JwtOptions
{
    public string SecretKey { get; set; }
    public int ExpiresHours { get; set; }
}