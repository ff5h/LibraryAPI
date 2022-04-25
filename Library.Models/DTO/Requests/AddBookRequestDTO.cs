﻿namespace Library.Models.DTO.Requests
{
    public class AddBookRequestDTO
    {
        public string Title { get; init; }
        public string Author { get; init; }
        public string Publisher { get; init; }
        public int Pages { get; init; }
        public float Price { get; init; }
    }
}
