using AutoMapper;
using NetCore_Project.DTO.DataDTO;
using NetCore_Project.Models;
using System.Linq.Expressions;

namespace NetCore_Project.DTO
{
    public class ConvertDtoToEntity
    {
        /// <summary>
        /// Hàm chuyển đổi từ DTO thành entity:
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static TTarget ConvertToEntity<TSource, TTarget>(TSource source)
        where TSource : class
        where TTarget : class, new()
        {
            var target = new TTarget();

            var sourceProperties = source.GetType().GetProperties();
            var targetProperties = typeof(TTarget).GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                var targetProperty = targetProperties.FirstOrDefault(x => x.Name == sourceProperty.Name);

                if (targetProperty != null)
                {
                    var value = sourceProperty.GetValue(source);
                    targetProperty.SetValue(target, value);
                }
            }

            return target;
        }

        /// <summary>
        /// Hàm chuyển đổi từ List<> thành entity:
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static List<TTarget> ConvertListDtoToListEntity<TSource, TTarget>(List<TSource> sourceList)
        {
            var entityList = new List<TTarget>();

            foreach (var source in sourceList)
            {
                var entity = ConvertToEntityList<TSource, TTarget>(source);
                entityList.Add(entity);
            }

            return entityList;
        }
        public static TTarget ConvertToEntityList<TSource, TTarget>(TSource source)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TTarget>()).CreateMapper();
            var entity = mapper.Map<TTarget>(source);

            return entity;
        }

        /// <summary>
        /// Hàm chuyển đổi từ entity quan DTO
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TTarget ConvertToDto<TSource, TTarget>(TSource source)
        where TSource : class
        where TTarget : class, new()
        {
            var target = new TTarget();

            var sourceProperties = source.GetType().GetProperties();
            var targetProperties = typeof(TTarget).GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                var targetProperty = targetProperties.FirstOrDefault(x => x.Name == sourceProperty.Name);

                if (targetProperty != null)
                {
                    var value = sourceProperty.GetValue(source);
                    targetProperty.SetValue(target, value);
                }
            }

            return target;
        }
    }
}
