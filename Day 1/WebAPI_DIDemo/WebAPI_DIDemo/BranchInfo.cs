namespace WebAPI_DIDemo
{
    public class BranchInfo
    {
        public int BranchNo { get; set; }
        public string BranchName { get; set; }
        public string BranchCity { get; set; }

        private List<BranchInfo> _branches = new List<BranchInfo>();

        public List<BranchInfo> Branches()
        {
            return _branches;
        }

        public string AddBranch(BranchInfo br)
        {
            _branches.Add(br);
            return "Branch Added";
        }
        public string RemoveBranch(BranchInfo br)
        {
            var b = (from bn in _branches
                    where bn.BranchNo == br.BranchNo
                    select bn).Single();
            _branches.Remove(b);
            return "Branch Deleted";

        }

        public string EditBranch(BranchInfo br)
        {
            var b = (from bn in _branches
                     where bn.BranchNo == br.BranchNo
                     select bn).Single();

            b.BranchCity = br.BranchCity;
            b.BranchName = br.BranchName;
            return "Branch Details changed";
        }
    }
}
