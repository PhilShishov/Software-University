
namespace CustomAutoMapper
{
    using System;
    using System.Reflection;
    using System.Linq;
    using System.Collections;

    using Automapper;

    public class Mapper
    {
        public T Map<T>(object source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(ExceptionUtils.NullSource);
            }

            T dest = (T)Activator.CreateInstance(typeof(T));

            return DoMapping<T>(source, dest);
        }

        private T DoMapping<T>(object source, T dest)
        {
            var properties = dest
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanWrite);

            var srcProperties = source
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);


            foreach (var property in properties)
            {
                var srcProperty = srcProperties.
                    Where(p => p.Name == property.Name)
                    .FirstOrDefault();

                if (srcProperty == null)
                {
                    continue;
                }

                var sourceValue = srcProperty.GetMethod.Invoke(source, new object[0]);

                if (ReflectionUtils.IsPrimitive(sourceValue.GetType()))
                {
                    property.SetValue(dest, srcProperty.GetValue(source));

                    continue;
                }

                if (ReflectionUtils.IsGenericCollection(sourceValue.GetType()))
                {
                    if (ReflectionUtils.IsPrimitive(sourceValue.GetType().GetGenericArguments()[0]))
                    {
                        var destinationCollection = sourceValue;
                        property.SetMethod.Invoke(dest, new[] { destinationCollection });
                    }
                    else
                    {
                        var destColl = property.GetMethod.Invoke(dest, new object[0]);
                        var destType = destColl.GetType().GetGenericArguments()[0];

                        foreach (var destP in (IEnumerable)sourceValue)
                        {
                            ((IList)destColl).Add(this.DoMapping(destP, destType));
                        }
                    }
                }
                else if (ReflectionUtils.IsNonGenericCollection(sourceValue.GetType()))
                {
                    var destColl = (IList)Activator.CreateInstance(property.PropertyType,
                        new object[] { ((object[])sourceValue).Length });

                    for (int i = 0; i < ((object[])sourceValue).Length; i++)
                    {
                        destColl[i] = this.DoMapping(((object[])sourceValue)[i],
                            property.PropertyType.GetElementType());
                    }

                    property.SetValue(dest, destColl);
                }
                else
                {
                    var propertyInstance = Activator.CreateInstance(srcProperty.GetValue(source).GetType());
                    property.SetValue(dest,
                        this.DoMapping(srcProperty.GetValue(source), propertyInstance));
                }
            }

            return dest;
        }

        private object CreateMappedObject(object source, Type ret)
        {
            if (source == null || ret == null)
            {
                throw new ArgumentException(ExceptionUtils.NullSourceValueOrReturnType);
            }

            var dest = Activator.CreateInstance(ret);

            return DoMapping(source, dest);
        }
    }

}
