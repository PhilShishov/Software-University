namespace P01.Stream_Progress.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IStreamable
    {
        int Length { get; set; }

        int BytesSent { get; set; }
    }
}