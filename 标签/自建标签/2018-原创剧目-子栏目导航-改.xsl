<?xml version="1.0" encoding="utf-8"?>
<xsl:transform version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:pe="labelproc" exclude-result-prefixes="pe">
    <xsl:param name="nodeId" />
    <xsl:param name="currentId" />
    <xsl:output method="html" />
    <xsl:template match="/">
        <ul>
            <xsl:attribute name="class">nav nav-pills mb-3</xsl:attribute>
            <xsl:attribute name="id">pills-tab</xsl:attribute>
            <xsl:attribute name="role">tablist</xsl:attribute>
            <xsl:for-each select="/NewDataSet/Table">
                <li>
                    <xsl:attribute name="class">nav-item
                        <xsl:if test="NodeID = $currentId">class_on</xsl:if>
                    </xsl:attribute>
                    <a>

                        <xsl:attribute name="class">nav-link <xsl:if test="NodeID = $currentId">active</xsl:if></xsl:attribute>
                        <xsl:attribute name="id">pills-home-tab</xsl:attribute>
                        <xsl:attribute name="data-toggle">pill</xsl:attribute>
                        <xsl:attribute name="href">#pills-home-<xsl:value-of select="NodeID" /></xsl:attribute>
                        <xsl:attribute name="role">tab</xsl:attribute>
                        <xsl:attribute name="aria-controls">pills-home</xsl:attribute>
                        <xsl:attribute name="aria-selected">true</xsl:attribute>
                        <xsl:value-of select="NodeName"/>
                    </a>
                </li>
            </xsl:for-each>
        </ul>

        <div>
            <xsl:attribute name="class">tab-content</xsl:attribute>
            <xsl:attribute name="id">pills-tabContent</xsl:attribute>
            <xsl:for-each select="/NewDataSet/Table">
                {pe.label id="2018-原创剧目-子栏目内容" nodeid="<xsl:value-of select="NodeID" />" currentid="<xsl:value-of select="$currentId" />" /}
            </xsl:for-each>
        </div>
    </xsl:template>
</xsl:transform>
