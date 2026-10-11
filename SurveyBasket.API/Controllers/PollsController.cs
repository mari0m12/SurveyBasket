using SurveyBasket.Models;

namespace SurveyBasket.Controllers;


[Route("api/[controller]")]  // /api/Polls
[ApiController]
public class PollsController(IPollServices? pollServices) : ControllerBase   // primary con
{
    //private readonly List<Poll> _polls = [
    //    new Poll(){
    //        Id =1,
    //        Title = "Poll 1",
    //        Description = "11111"
    //    }
    //    ]; 
    // or  = new List<Poll>();  or = new();
    private readonly IPollServices? _pollServices = pollServices;  // primary con

    [HttpGet("GetAll")] // or [HttpGet("")]
    //[Route("GetAll")] // عشان لو عندي 2 اكشن زي بعض باختلاف الاسم or [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_pollServices.GetAll()); // status code 200
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var poll = _pollServices.Get(id);
        return poll is null ? NotFound() : Ok(poll);
    }

    [HttpPost("")] // Template
    public IActionResult Add(Poll poll)
    {
        var newpoll = _pollServices?.Add(poll);
        // return Ok(newpolls); 200   العملية نجحت وعايزين نرجّع بيانات.
        // return Created();    201	أنشأنا Resource جديد وبنحدد عنوانه.
        return CreatedAtAction(nameof(GetById), new { id = newpoll.Id }, newpoll);  // 201	أنشأنا Resource جديد وعايزين ASP.NET Core يولّد عنوانه من Action موجودة.
    }


    [HttpPut("{id}")]
    public IActionResult Update(int id, Poll poll)
    {
        var isUpdated = _pollServices?.Update(id, poll);

        if (isUpdated == false) return NotFound();

        return NoContent();  // status code 204
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = _pollServices?.Delete(id);

        if (isDeleted == false) return NotFound();

        return NoContent();
    }
}

//بترجّعي 201 Created،
//وبتطلبي من ASP.NET Core تكوين رابط للـ Action اسمها Get باستخدام
//الـ ID بتاع الاستطلاع الجديد.

