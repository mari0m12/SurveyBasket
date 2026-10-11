
using SurveyBasket.Models;

namespace SurveyBasket.Sevices
{
    public class PollServices : IPollServices
    {
        private static readonly List<Poll> _polls = [
        new Poll(){
            Id =1,
            Title = "Poll 1",
            Description = "11111"
        }
        ];
        public IEnumerable<Poll> GetAll() => _polls;
        //{
        //    return _polls;
        //}
        public Poll? Get(int id) => _polls.SingleOrDefault(x => x.Id == id);

        public Poll Add(Poll poll)
        {
            poll.Id = _polls.Count + 1;
            _polls.Add(poll);
            return poll;
        }

        public bool Update(int id, Poll poll)
        {
            var curpoll = Get(id);
            if (curpoll == null) return false;
            curpoll.Title = poll.Title;
            curpoll.Description = poll.Description;
            return true;
        }

        public bool Delete(int id)
        {
            var poll = Get(id);
            if (poll == null) return false;
            _polls.Remove(poll);
            return true;
        }
    }
}
// static بيخلي كل كائنات PollServices تشوف نفس قائمة الاستطلاعات.



// readonly بيمنع استبدال القائمة نفسها، لكنه لا يمنع تعديل محتوياتها.
