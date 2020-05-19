var name = Name.Split(' ');

var firstName = name[0];
var midleName = name[1];
var lastName = name[2];
var Users =
    _db.Users.Where(
        w =>
            (((w.Name.ToLower().StartsWith(firstName.ToLower()) &&
                w.Name.ToLower().Contains(midleName.ToLower())) &&
                (w.LastName.ToLower().StartsWith(lastName.ToLower())))
            ||
            (w.Name.ToLower().Equals(firstName.ToLower()) &&
                (w.LastName.ToLower().StartsWith(midleName.ToLower())) &&
                w.LastName.ToLower().Contains(lastName.ToLower())))
                && (!_db.Blocks.Any(x => (((x.BlockedByUserId == MyId && x.BlockedWhomUserId == w.Id && x.IsBlock) || (x.BlockedByUserId == w.Id && x.BlockedWhomUserId == MyId && x.IsBlock))))))

        .OrderByDescending(x => x.Name.ToLower().StartsWith(Name.ToLower()))
        .ToList();
var usersLean =
    Users.Select(
        w => new { w.Name, w.LastName, w.Id, ProfilemediumPath = w.GetProfilePictureThumb(Sizes.big) });
var response = new ApiResponseModel();
response.ResponseCode = ResponseCodes.Successful;
response.ResultPayload = usersLean;
return Ok(response);
