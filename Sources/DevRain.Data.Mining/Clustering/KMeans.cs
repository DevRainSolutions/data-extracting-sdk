using System;
using System.Collections.Generic;
using System.Linq;

namespace DevRain.Data.Mining.Clustering
{
   
/*
---------------JCA.java-------------

package org.c4s.algorithm.cluster;
import java.util.Vector;

/**

k-means Cluster Anlysis Algorithm
Author: Shyam Sivaraman
Email: 	shyam_siv@yahoo.com

The package aims at providing an implementation of k-means Clustering Algorithm in Java. 
The package does not provide for any UI and it is up to the user to display the output in the required format.

Source: http://www.sourcecodesworld.com/source/show.asp?ScriptID=807


This class is the entry point for constructing Cluster Analysis objects.
Each instance of JCA object is associated with one or more clusters, 
and a Vector of DataPoint objects. The JCA and DataPoint classes are
the only classes available from other packages.
@see DataPoint

**/

public class JCA {
    private Cluster[] clusters;
    private int miter;
    private List<DataPoint> mDataPoints = new List<DataPoint>();
    private double mSWCSS;

    public JCA(int k, int iter, List<DataPoint> dataPoints) {
        clusters = new Cluster[k];
        for (int i = 0; i < k; i++) {
            clusters[i] = new Cluster("Cluster" + i);
        }
        this.miter = iter;
        this.mDataPoints = dataPoints;
    }

    private void calcSWCSS() {
        double temp = 0;
        for (int i = 0; i < clusters.Length; i++) {
            temp = temp + clusters[i].getSumSqr();
        }
        mSWCSS = temp;
    }

    public void startAnalysis() {
        //set Starting centroid positions - Start of Step 1
        setInitialCentroids();
        int n = 0;
        //assign DataPoint to clusters
        while (true) {
            for (int l = 0; l < clusters.Length; l++) 
            {
                clusters[l].addDataPoint((DataPoint)mDataPoints[n]);
                n++;
                if (n >= mDataPoints.Count()){
                    break;
                }
            }
        }
        
        //calculate E for all the clusters
        calcSWCSS();
        
        //recalculate Cluster centroids - Start of Step 2
        for (int i = 0; i < clusters.Length; i++) {
            clusters[i].getCentroid().calcCentroid();
        }
        
        //recalculate E for all the clusters
        calcSWCSS();

        for (int i = 0; i < miter; i++) {
            //enter the loop for cluster 1
            for (int j = 0; j < clusters.Length; j++) {
                for (int k = 0; k < clusters[j].getNumDataPoints(); k++) {
                
                    //pick the first element of the first cluster
                    //get the current Euclidean distance
                    double tempEuDt = clusters[j].getDataPoint(k).getCurrentEuDt();
                    Cluster tempCluster = null;
                    Boolean matchFoundFlag = false;
                    
                    //call testEuclidean distance for all clusters
                    for (int l = 0; l < clusters.Length; l++) {
                    
                    //if testEuclidean < currentEuclidean then
                        if (tempEuDt > clusters[j].getDataPoint(k).testEuclideanDistance(clusters[l].getCentroid())) {
                            tempEuDt = clusters[j].getDataPoint(k).testEuclideanDistance(clusters[l].getCentroid());
                            tempCluster = clusters[l];
                            matchFoundFlag = true;
                        }
                        //if statement - Check whether the Last EuDt is > Present EuDt 
                        
                        }
//for variable 'l' - Looping between different Clusters for matching a Data Point.
//add DataPoint to the cluster and calcSWCSS

       if (matchFoundFlag) {
		tempCluster.addDataPoint(clusters[j].getDataPoint(k));
		clusters[j].removeDataPoint(clusters[j].getDataPoint(k));
                        for (int m = 0; m < clusters.Length; m++) {
                            clusters[m].getCentroid().calcCentroid();
                        }

//for variable 'm' - Recalculating centroids for all Clusters

                        calcSWCSS();
                    }
                    
//if statement - A Data Point is eligible for transfer between Clusters.
                }
                //for variable 'k' - Looping through all Data Points of the current Cluster.
            }//for variable 'j' - Looping through all the Clusters.
        }//for variable 'i' - Number of iterations.
    }

    public List<DataPoint>[] getClusterOutput() {
        var v = new List<DataPoint>[clusters.Length];
        for (int i = 0; i < clusters.Length; i++) {
            v[i] = clusters[i].getDataPoints();
        }
        return v;
    }


    private void setInitialCentroids() {
        //kn = (round((max-min)/k)*n)+min where n is from 0 to (k-1).
        double cx = 0, cy = 0;
        for (int n = 1; n <= clusters.Length; n++) {
            cx = (((getMaxXValue() - getMinXValue()) / (clusters.Length + 1)) * n) + getMinXValue();
            cy = (((getMaxYValue() - getMinYValue()) / (clusters.Length + 1)) * n) + getMinYValue();
            Centroid c1 = new Centroid(cx, cy);
            clusters[n - 1].setCentroid(c1);
            c1.setCluster(clusters[n - 1]);
        }
    }

    private double getMaxXValue() {
        double temp;
        temp = ((DataPoint) mDataPoints[0]).getX();
        for (int i = 0; i < mDataPoints.Count(); i++) {
            DataPoint dp = (DataPoint) mDataPoints[i];
            temp = (dp.getX() > temp) ? dp.getX() : temp;
        }
        return temp;
    }

    private double getMinXValue() {
        double temp = 0;
        temp = ((DataPoint) mDataPoints[0]).getX();
        for (int i = 0; i < mDataPoints.Count(); i++) {
            DataPoint dp = (DataPoint) mDataPoints[i];
            temp = (dp.getX() < temp) ? dp.getX() : temp;
        }
        return temp;
    }

    private double getMaxYValue() {
        double temp = 0;
        temp = ((DataPoint) mDataPoints[0]).getY();
        for (int i = 0; i < mDataPoints.Count(); i++) {
            DataPoint dp = (DataPoint) mDataPoints[i];
            temp = (dp.getY() > temp) ? dp.getY() : temp;
        }
        return temp;
    }

    private double getMinYValue() {
        double temp = 0;
        temp = ((DataPoint) mDataPoints[0]).getY();
        for (int i = 0; i < mDataPoints.Count(); i++) {
            DataPoint dp = (DataPoint) mDataPoints[i];
            temp = (dp.getY() < temp) ? dp.getY() : temp;
        }
        return temp;
    }

    public int getKValue() {
        return clusters.Length;
    }

    public int getIterations() {
        return miter;
    }

    public int getTotalDataPoints() {
        return mDataPoints.Count();
    }

    public double getSWCSS() {
        return mSWCSS;
    }

    public Cluster getCluster(int pos) {
        return clusters[pos];
    }
}

/*-----------------Cluster.java----------------*/


/**
 * This class represents a Cluster in a Cluster Analysis Instance. A Cluster is associated
 * with one and only one JCA Instance. A Cluster is related to more than one DataPoints and
 * one centroid.
 * @author Shyam Sivaraman
 * @version 1.1
 * @see DataPoint
 * @see Centroid
 */



public class Cluster {
    private String mName;
    private Centroid mCentroid;
    private double mSumSqr;
    private List<DataPoint> mDataPoints;

    public Cluster(String name) {
        this.mName = name;
        this.mCentroid = null; //will be set by calling setCentroid()
        mDataPoints = new List<DataPoint>();
    }

    public void setCentroid(Centroid c) {
        mCentroid = c;
    }

    public Centroid getCentroid() {
        return mCentroid;
    }

    public void addDataPoint(DataPoint dp) { //called from CAInstance
        dp.setCluster(this); //initiates a inner call to calcEuclideanDistance() in DP.
        this.mDataPoints.Add(dp);
        calcSumOfSquares();
    }

    public void removeDataPoint(DataPoint dp) {
        this.mDataPoints.Remove(dp);
        calcSumOfSquares();
    }

    public int getNumDataPoints() {
        return this.mDataPoints.Count;
    }

    public DataPoint getDataPoint(int pos) {
        return (DataPoint) this.mDataPoints[pos];
    }

    public void calcSumOfSquares() { //called from Centroid
        int size = this.mDataPoints.Count;
        double temp = 0;
        for (int i = 0; i < size; i++) {
            temp = temp + ((DataPoint) this.mDataPoints[i]).getCurrentEuDt();
        }
        this.mSumSqr = temp;
    }

    public double getSumSqr() {
        return this.mSumSqr;
    }

    public String getName() {
        return this.mName;
    }

    public List<DataPoint> getDataPoints() {
        return this.mDataPoints;
    }

}

/*---------------Centroid.java-----------------*/


/**
 * This class represents the Centroid for a Cluster. The initial centroid is calculated
 * using a equation which divides the sample space for each dimension into equal parts
 * depending upon the value of k.
 * @author Shyam Sivaraman
 * @version 1.0
 * @see Cluster
 */

public class Centroid {
    private double mCx, mCy;
    private Cluster mCluster;

    public Centroid(double cx, double cy) {
        this.mCx = cx;
        this.mCy = cy;
    }

    public void calcCentroid() { //only called by CAInstance
        int numDP = mCluster.getNumDataPoints();
        double tempX = 0, tempY = 0;
        int i;
        //caluclating the new Centroid
        for (i = 0; i < numDP; i++) {
            tempX = tempX + mCluster.getDataPoint(i).getX(); 
            //total for x
            tempY = tempY + mCluster.getDataPoint(i).getY(); 
            //total for y
        }
        this.mCx = tempX / numDP;
        this.mCy = tempY / numDP;
        //calculating the new Euclidean Distance for each Data Point
        tempX = 0;
        tempY = 0;
        for (i = 0; i < numDP; i++) {
            mCluster.getDataPoint(i).calcEuclideanDistance();
        }
        //calculate the new Sum of Squares for the Cluster
        mCluster.calcSumOfSquares();
    }

    public void setCluster(Cluster c) {
        this.mCluster = c;
    }

    public double getCx() {
        return mCx;
    }

    public double getCy() {
        return mCy;
    }

    public Cluster getCluster() {
        return mCluster;
    }

}

/*----------------DataPoint.java----------------*/


/**
    This class represents a candidate for Cluster analysis. A candidate must have
    a name and two independent variables on the basis of which it is to be clustered.
    A Data Point must have two variables and a name. A Vector of  Data Point object
    is fed into the constructor of the JCA class. JCA and DataPoint are the only
    classes which may be available from other packages.
    @author Shyam Sivaraman
    @version 1.0
    @see JCA
    @see Cluster
*/

public class DataPoint {
    private double mX,mY;
    private String mObjName;
    private Cluster mCluster;
    private double mEuDt;

    public DataPoint(double x, double y, String name) {
        this.mX = x;
        this.mY = y;
        this.mObjName = name;
        this.mCluster = null;
    }

    public void setCluster(Cluster cluster) {
        this.mCluster = cluster;
        calcEuclideanDistance();
    }

    public void calcEuclideanDistance() { 
    
    //called when DP is added to a cluster or when a Centroid is recalculated.
        mEuDt = Math.Sqrt(Math.Pow((mX - mCluster.getCentroid().getCx()),
2) + Math.Pow((mY - mCluster.getCentroid().getCy()), 2));
    }

    public double testEuclideanDistance(Centroid c) {
        return Math.Sqrt(Math.Pow((mX - c.getCx()), 2) + Math.Pow((mY - c.getCy()), 2));
    }

    public double getX() {
        return mX;
    }

    public double getY() {
        return mY;
    }

    public Cluster getCluster() {
        return mCluster;
    }

    public double getCurrentEuDt() {
        return mEuDt;
    }

    public String getObjName() {
        return mObjName;
    }

}

/*-----------------PrgMain.java---------------*/

/**
 * Created by IntelliJ IDEA.
 * User: shyam.s
 * Date: Apr 18, 2004
 * Time: 4:26:06 PM
 *//*
public class PrgMain {
    public static void main (String args[]){
        List<DataPoint> dataPoints = new List<DataPoint>();
        dataPoints.Add(new DataPoint(22,21,"p53"));
        dataPoints.Add(new DataPoint(19,20,"bcl2"));
        dataPoints.Add(new DataPoint(18,22,"fas"));
        dataPoints.Add(new DataPoint(1,3,"amylase"));
        dataPoints.Add(new DataPoint(3,2,"maltase"));

        JCA jca = new JCA(2,1000,dataPoints);
        jca.startAnalysis();

        var v = jca.getClusterOutput();
        for (int i=0; i<v.Length; i++){
            List<DataPoint> tempV = v[i];
            System.Console.WriteLine("-----------Cluster"+i+"---------");
            Iterator iter = tempV.iterator();
            while(iter.hasNext()){
                DataPoint dpTemp = (DataPoint)iter.next();
                System.Console.WriteLine(dpTemp.getObjName()+"["+dpTemp.getX()+","+dpTemp.getY()+"]");
            }
        }
    }
}*/
}