﻿#if (NETCOREAPP3_0 || NETCOREAPP3_1 || NETSTANDARD2_1)
#define SUPPORT_NETSTANDARD2_1_AND_ABOVE
#endif

#if (NETCOREAPP3_1 || NETCOREAPP3_0 || NETCOREAPP2_2 || NETCOREAPP2_1)
#define CORE2_1_AND_ABOVE
#endif

using System;
using System.CodeDom.Compiler;
using System.Linq;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    [GeneratedCode("ProductivityExtensionMethods", "VersionPlaceholder{D8B1B561-500C-4086-91AA-0714457205DA}")]
    public static partial class EnumerableExtensions
    {
        #region  Public Methods

        public static bool Contains<TSource>(this IEnumerable<TSource> sources, TSource obj, Func<TSource, TSource, bool> comparer)
        {
            return Contains(sources, obj, comparer, null);
        }

        public static bool Contains<TSource>(this IEnumerable<TSource> sources, TSource obj, Func<TSource, TSource, bool> comparer, Func<TSource, int>? hash)
        {
            IEqualityComparer<TSource> equalityComparer = hash == null ? new ProductivityExtensionMethods.Common.EqualityComparer<TSource>(comparer) : new ProductivityExtensionMethods.Common.EqualityComparer<TSource>(comparer, hash);

            return sources.Contains(obj, equalityComparer);
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, TKey, bool> keyComparer, Func<TKey, int> keyHashCalculator)
        {
            IEqualityComparer<TKey> equalityComparer = keyHashCalculator == null ? new ProductivityExtensionMethods.Common.EqualityComparer<TKey>(keyComparer) : new ProductivityExtensionMethods.Common.EqualityComparer<TKey>(keyComparer, keyHashCalculator);

            return source.ToDictionary(keySelector, elementSelector, equalityComparer);
        }

        /// <summary>
        ///     When doing group by, resulting IEnumerable is inherently a dictionary. This method conviniently converts it to an
        ///     Dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Dictionary<TKey, TElement[]> ToDictionary<TKey, TElement>(this IEnumerable<IGrouping<TKey, TElement>> source)
        {
            return source.ToDictionary(it => it.Key, it => it.ToArray());
        }

        /// <summary>
        ///     When doing group by, resulting IEnumerable is inherently a dictionary. This method conviniently converts it to an
        ///     Dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="keyComparer"></param>
        /// <returns></returns>
        public static Dictionary<TKey, TElement[]> ToDictionary<TKey, TElement>(this IEnumerable<IGrouping<TKey, TElement>> source, Func<TKey, TKey, bool> keyComparer)
        {
            return ToDictionary(source, keyComparer, null);
        }

        /// <summary>
        ///     When doing group by, resulting IEnumerable is inherently a dictionary. This method conviniently converts it to an
        ///     Dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="keyComparer"></param>
        /// <param name="keyHashCalculator"></param>
        /// <returns></returns>
        public static Dictionary<TKey, TElement[]> ToDictionary<TKey, TElement>(this IEnumerable<IGrouping<TKey, TElement>> source, Func<TKey, TKey, bool> keyComparer, Func<TKey, int>? keyHashCalculator)
        {
            IEqualityComparer<TKey> equalityComparer = keyHashCalculator == null ? new ProductivityExtensionMethods.Common.EqualityComparer<TKey>(keyComparer) : new ProductivityExtensionMethods.Common.EqualityComparer<TKey>(keyComparer, keyHashCalculator);

            return ToDictionary(source, equalityComparer);
        }

        /// <summary>
        ///     When doing group by, resulting IEnumerable is inherently a dictionary. This method conviniently converts it to an
        ///     Dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="equalityComparer"></param>
        /// <returns></returns>
        public static Dictionary<TKey, TElement[]> ToDictionary<TKey, TElement>(this IEnumerable<IGrouping<TKey, TElement>> source, IEqualityComparer<TKey> equalityComparer)
        {
            IEnumerable<IGrouping<TKey, IGrouping<TKey, TElement>>> uniqueKeyGroupBy = source.GroupBy(grp => grp.Key, equalityComparer);

            return uniqueKeyGroupBy.ToDictionary(it => it.Key, it => it.SelectMany(i => i).ToArray(), equalityComparer);
        }

        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> sources, Func<TSource, TSource, bool> comparer)
        {
            return sources.Distinct(new ProductivityExtensionMethods.Common.EqualityComparer<TSource>(comparer));
        }

        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> sources, Func<TSource, TSource, bool> comparer, Func<TSource, int> hashCalculator)
        {
            return sources.Distinct(new ProductivityExtensionMethods.Common.EqualityComparer<TSource>(comparer, hashCalculator));
        }

        /// <summary>
        ///     Converts a flat list of TEntity to a hierarchy of <typeparamref name="TNode" />, optimized for very large number of
        ///     items.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity</typeparam>
        /// <typeparam name="TNode">The type of the node in the hierarchy</typeparam>
        /// <typeparam name="TKey">The type of the identifier</typeparam>
        /// <param name="source">the source list</param>
        /// <param name="convertor">
        ///     The function to use for casting a <typeparamref name="TEntity" /> to a
        ///     <typeparamref name="TNode" />. return null ignore the <typeparamref name="TEntity" />.
        /// </param>
        /// <param name="getKey">
        ///     The function to use for extracting the key from a <typeparamref name="TEntity" />. return null
        ///     ignore the <typeparamref name="TEntity" />.
        /// </param>
        /// <param name="getParentKey">
        ///     The function to use for extracting the parent key of a <typeparamref name="TEntity" />.
        ///     return null to explicitly indicate the <typeparamref name="TEntity" /> as root (performance upside).
        /// </param>
        /// <param name="firstIsParentOfSecond">The function to call whenever a child of a parent node is found.</param>
        /// <remarks>
        ///     The order of the operation is O(n). Implementation performs optimized loop if the instance is a generic List or
        ///     even better an array, but
        ///     do not create new instances of generic list or array to pass in, since the overall performance will be lower.
        /// </remarks>
        /// <returns>the IEnumerable of root <typeparamref name="TNode" /></returns>
        public static IEnumerable<TNode> ToHierarchy<TEntity, TKey, TNode>(this IEnumerable<TEntity> source, Func<TEntity, TNode?> convertor, Func<TEntity, TKey?> getKey, Func<TEntity, TKey?> getParentKey, Action<TNode, TNode> firstIsParentOfSecond) where TKey : struct
                                                                                                                                                                                                                                                          where TNode : class
                                                                                                                                                                                                                                                          where TEntity : class
        {
            return ToHierarchy(source, null, convertor, getKey, getParentKey, firstIsParentOfSecond);
        }

        /// <summary>
        ///     Converts a flat list of TEntity to a hierarchy of <typeparamref name="TNode" />, optimized for very large number of
        ///     items.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity</typeparam>
        /// <typeparam name="TNode">The type of the node in the hierarchy</typeparam>
        /// <typeparam name="TKey">The type of the identifier</typeparam>
        /// <param name="source">the source list.</param>
        /// <param name="keycomparer">
        ///     a comparer to use for compare and get hash code of the entity keys returned by the getKey and
        ///     getParentKey functions
        /// </param>
        /// <param name="convertor">
        ///     The function to use for casting a <typeparamref name="TEntity" /> to a
        ///     <typeparamref name="TNode" />. return null to ignore the <typeparamref name="TEntity" />.
        /// </param>
        /// <param name="getKey">
        ///     The function to use for extracting the key from a <typeparamref name="TEntity" />. return null to
        ///     ignore the <typeparamref name="TEntity" />.
        /// </param>
        /// <param name="getParentKey">
        ///     The function to use for extracting the parent key of a <typeparamref name="TEntity" />.
        ///     return null to explicitly indicate the <typeparamref name="TEntity" /> as root.
        /// </param>
        /// <param name="firstIsParentOfSecond">The function to call whenever a child of a parent node is found.</param>
        /// <remarks>
        ///     The order of the operation is O(n). Implementation performs optimized loop if the instance is a generic List or
        ///     even better an array, but
        ///     do not create new instances of generic list or array to pass in, since the overall performance will be lower.
        /// </remarks>
        /// <returns>the IEnumerable of root <typeparamref name="TNode" /></returns>
        public static IEnumerable<TNode> ToHierarchy<TEntity, TKey, TNode>(this IEnumerable<TEntity> source, IEqualityComparer<TKey>? keycomparer, Func<TEntity, TNode?> convertor, Func<TEntity, TKey?> getKey, Func<TEntity, TKey?> getParentKey, Action<TNode, TNode> firstIsParentOfSecond) where TKey : struct
                                                                                                                                                                                                                                                                                                where TNode : class
                                                                                                                                                                                                                                                                                                where TEntity : class
        {
            Dictionary<TKey, TreeNode<TEntity, TKey, TNode>> parents;

            switch (source)
            {
                case ICollection<TEntity> collection2:
                    parents = new Dictionary<TKey, TreeNode<TEntity, TKey, TNode>>(collection2.Count, keycomparer);
                    break;
                case ICollection collection:
                    parents = new Dictionary<TKey, TreeNode<TEntity, TKey, TNode>>(collection.Count, keycomparer);
                    break;
                default:
                    parents = new Dictionary<TKey, TreeNode<TEntity, TKey, TNode>>(keycomparer);
                    break;
            }

            var explicitNoParentItems = new List<TreeNode<TEntity, TKey, TNode>>();
            var orphanage = new Dictionary<TKey, List<TreeNode<TEntity, TKey, TNode>>>(keycomparer);

            switch (source) // each case is handled differently by compiler for performance reason. Body of each case will be inlined by the compiler
            {
                case TEntity[] sourceArray:
                    foreach (TEntity v in sourceArray)
                        DoConvertToHierarchy(convertor, getKey, getParentKey, firstIsParentOfSecond, v, parents, orphanage, explicitNoParentItems);
                    break;
                case List<TEntity> sourceList:
                    foreach (TEntity v in sourceList)
                        DoConvertToHierarchy(convertor, getKey, getParentKey, firstIsParentOfSecond, v, parents, orphanage, explicitNoParentItems);
                    break;
                default:
                    foreach (TEntity v in source)
                        DoConvertToHierarchy(convertor, getKey, getParentKey, firstIsParentOfSecond, v, parents, orphanage, explicitNoParentItems);
                    break;
            }

            return (from node in explicitNoParentItems
                    select node.Node)
               .Concat(from room in orphanage.Values // There maybe some items that claimed to have parents, but we did not encounter the parent ID. We add them to the root.
                       from node2 in room
                       select node2.Node);
        }

        #endregion

        #region Private Methods

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DoConvertToHierarchy<TEntity, TKey, TNode>(Func<TEntity, TNode?> convertor, Func<TEntity, TKey?> getKey, Func<TEntity, TKey?> getParentKey, Action<TNode, TNode> firstIsParentOfSecond, TEntity v, Dictionary<TKey, TreeNode<TEntity, TKey, TNode>> parents, Dictionary<TKey, List<TreeNode<TEntity, TKey, TNode>>> orphanage, List<TreeNode<TEntity, TKey, TNode>> explicitNoParentItems) where TKey : struct
                                                                                                                                                                                                                                                                                                                                                                                                                       where TNode : class
                                                                                                                                                                                                                                                                                                                                                                                                                       where TEntity : class
        {
            if (v == null)
                return;

            TNode? castedNode = convertor(v);
            if (castedNode == null)
                return;

            var node = new TreeNode<TEntity, TKey, TNode>();

            TKey? nodeKey = getKey(v);
            if (!nodeKey.HasValue)
                return;

            node = new TreeNode<TEntity, TKey, TNode>(castedNode, getParentKey(v), nodeKey.Value);

            //finding parent of the node
            if (node.ParentKey.HasValue)
            {
                TreeNode<TEntity, TKey, TNode> parentNode;

                if (parents.TryGetValue(node.ParentKey.Value, out parentNode))
                {
                    firstIsParentOfSecond(parentNode.Node, node.Node);
                }
                else
                {
                    //poor node :( no parent found! it should go to the orphanage
                    if (!orphanage.TryGetValue(node.ParentKey.Value, out List<TreeNode<TEntity, TKey, TNode>> orphanageRoom2))
                    {
                        orphanageRoom2 = new List<TreeNode<TEntity, TKey, TNode>>();
                        orphanage.Add(node.ParentKey.Value, orphanageRoom2);
                    }

                    orphanageRoom2.Add(node);
                }
            }
            else
            {
                explicitNoParentItems.Add(node);
            }

            //checking if there are any orphans whose parent is this new node object.
            if (orphanage.TryGetValue(node.NodeKey, out List<TreeNode<TEntity, TKey, TNode>> orphanageRoom))
            {
                foreach (TreeNode<TEntity, TKey, TNode> v2 in orphanageRoom)
                    firstIsParentOfSecond(node.Node, v2.Node);

                orphanage.Remove(node.NodeKey); //there would be no more orphans for this parent, so removing the orphanage room
            }

            parents.Add(node.NodeKey, node);
        }

        #endregion

        #region Nested types

        private readonly struct TreeNode<TEntity, TKey, TNode> where TKey : struct
        {
            #region Fields

            public readonly TNode Node;

            public readonly TKey NodeKey;
            public readonly TKey? ParentKey;

            #endregion

            #region Constructors

            public TreeNode(TNode node, TKey? parentKey, TKey nodeKey)
            {
                Node = node;
                ParentKey = parentKey;
                NodeKey = nodeKey;
            }

            #endregion
        }

        #endregion
    }
}