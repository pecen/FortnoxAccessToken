using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxAccessToken.Utilities.Extensions {
  /// <summary>
  /// Class resolving names of the used properties.
  /// </summary>
  public static class Name {
    /// <summary>
    /// Returns property name used in the selector.
    /// </summary>
    /// <param name="selector">The property selector.</param>
    /// <returns>Name of the property.</returns>
    public static string Of(LambdaExpression selector) {
      if (selector == null) {
        throw new ArgumentNullException(nameof(selector));
      }

      MemberExpression mexp = selector.Body as MemberExpression;
      if (mexp == null) {
        UnaryExpression uexp = (selector.Body as UnaryExpression);
        if (uexp == null) {
          throw new ArgumentException("Cannot determine the name of a member using an expression because the expression provided cannot be converted to a '" + typeof(UnaryExpression).Name);
        }

        mexp = uexp.Operand as MemberExpression;
      }

      if (mexp == null) {
        throw new ArgumentException("Cannot determine the name of a member using an expression because the expression provided cannot be converted to a '" + typeof(MemberExpression).Name);
      }

      return mexp.Member.Name;
    }

    /// <summary>
    /// Returns property name used in the selector.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <param name="selector">The property selector.</param>
    /// <returns>Name of the property.</returns>
    public static string Of<TSource>(Expression<Func<TSource, object>> selector) {
      return Of<TSource, object>(selector);
    }

    /// <summary>
    /// Returns property name used in the selector.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="selector">The property selector.</param>
    /// <returns>Name of the property.</returns>
    [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Only expressions expected.")]
    public static string Of<TSource, TResult>(Expression<Func<TSource, TResult>> selector) {
      return Of(selector as LambdaExpression);
    }
  }

  /// <summary>
  /// Extends classes with selecting property name.
  /// </summary>
  public static class NameExtensions {
    /// <summary>
    /// Returns property name used in the selector.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="obj">The object instance.</param>
    /// <param name="selector">The property selector.</param>
    /// <returns>Name of the property.</returns>
    [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "obj", Justification = "It's only for compilator to use extension method.")]
    public static string NameOf<TSource, TResult>(this TSource obj, Expression<Func<TSource, TResult>> selector) {
      return Name.Of(selector);
    }
  }
}
