[Authorize]
[HttpPost]
public dynamic BlockUser(BlockModelView block)
{
    string appUserId = User.Identity.GetUserId();
    var appUser = _context.Users.First(x=>x.Id==appUserId);
    var blockUser = _context.Users.First(x => x.Id == block.BlockedWhomUserId);
    if (blockUser != null)
    {
        var isUserInBlockList = _context.Blocks.Any(x => x.BlockedByUserId == appUserId && x.BlockedWhomUserId==block.BlockedWhomUserId && x.IsBlock);

        if (!isUserInBlockList)
        {
            _context.Blocks.Add(new Block()
            {
                BlockedByUserId = appUserId,
                BlockedWhomUserId = block.BlockedWhomUserId,
                IsBlock = true,
                Time = DateTime.Now
            });
            _context.SaveChanges();
            return new
            {
                res = true,
                msg = "This user added to your block list"
            };
        }
        else
        {
            return new
            {
                res = true,
                msg = "This user already in block list"
            };
        }
    }
    return new
    {
        res=false,
        msg="No user found"
    };

}