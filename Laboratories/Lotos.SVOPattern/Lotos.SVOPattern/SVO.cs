namespace Lotos.SVOPattern
{
	public class SVO
	{
		private SubjectObject so;
		private SubjectProperty sp;
		private SVO SiblignSVO;
		public SVO(SubjectObject obj, SubjectProperty property)
		{
			this.so = obj;
			this.sp = property;
		}

		public SVO And(SVO svo)
		{
			this.SiblignSVO = svo;
			return this;
		}
		public override string ToString()
		{
			if (null != this.SiblignSVO)
			{
				return "(" + so + sp + ")" + " and " + this.SiblignSVO;
			}
			return "(" + so + sp + ")";
		}
	}
}
