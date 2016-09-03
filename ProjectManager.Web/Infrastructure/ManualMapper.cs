using System;
using System.Linq;

namespace ProjectManager.Web
{
    /// <summary>
    /// Maps a viewModel to a domain Model.
    /// </summary>
    public class ModelMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Tsource">View Model to map</typeparam>
        /// <typeparam name="Ttarget">Domain Model to Map to</typeparam>
        /// <param name="sourceModel"></param>
        /// <param name="targetModel"></param>
        /// <returns></returns>
        public bool Map<Tsource, Ttarget>(Tsource sourceModel, Ttarget targetModel)
            where Tsource : class, new()
            where Ttarget : class, new()
        {
            if (sourceModel != null && targetModel != null)
            {
                try
                {
                    sourceModel.GetType().GetProperties().ToList().ForEach(s =>
                    {
                        targetModel.GetType().GetProperties()
                            .Where(p => string.Equals(p.Name, s.Name))
                            .FirstOrDefault().SetValue(targetModel, s.GetValue(sourceModel));
                    });
                    return true;
                }
                catch (ArgumentNullException)
                {
                    return false;
                }
            }
            return false;
        }
    }
}