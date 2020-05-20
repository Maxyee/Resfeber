[System.Web.Http.Route("interest")]
public IHttpActionResult GetInterestPictures()
{
    var response = new ApiResponseModel();

    try
    {
        
        IEnumerable<InterestFeed> interestFeedData = Db.InterestFeeds.ToList();
        
        response.ResponseCode = ResponseCodes.Successful;
        response.Message = "Pictures successfully retrieved";
        response.ResultPayload = new
        {
            interestFeedData
        };
        return Ok(response);
    }
    catch (Exception ex)
    {
        return InternalServerError(ex);
    }

}            