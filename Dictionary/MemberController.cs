using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    class MemberController
    {
        private Dictionary<int, Member> actives = new Dictionary<int, Member>();
        private Dictionary<int, Member> passives = new Dictionary<int, Member>();

        public void AddMember(MemberType memberType, Member m)
        {
            if (m != null)
            {
                if (IdAlreadyUsed(m.Id) == false)
                {
                    if (memberType == MemberType.active)
                    {
                        actives.Add(m.Id, m);
                    }
                    else
                    {
                        passives.Add(m.Id, m);
                    }
                }
            }
        }

        public bool IdAlreadyUsed(int id)
        {
            if (actives.ContainsKey(id) || passives.ContainsKey(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Member> Getmembers()
        {
            List<Member> list = new List<Member>();

            foreach (KeyValuePair<int, Member> item in actives)
            {
                list.Add(item.Value);
            }
            foreach (KeyValuePair<int, Member> item in passives)
            {
                list.Add(item.Value);
            }

            return list;
        }

        public bool DeleteMember(int id)
        {
            bool result = false;

            if (actives.ContainsKey(id))
            {
                actives.Remove(id);
                result = true;
            }
            if (passives.ContainsKey(id))
            {
                passives.Remove(id);
                result = true;
            }

            return result;
        }
    }
}

