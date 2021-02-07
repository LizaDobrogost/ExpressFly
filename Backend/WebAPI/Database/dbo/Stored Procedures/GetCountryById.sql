create procedure GetCountryById
    @id as int
as
    select *
    from Countries
    where Id = @id